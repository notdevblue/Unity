using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent    enemyAgent;
    private Transform       playerTrm;
    public  LayerMask       whatIsGround;
    public  LayerMask       whatIsPlayer;

    // Patrol
    public  Vector3 walkPoint;
    public  float   walkPointRange;
    private bool    bWalkPointSet;

    // attack
    public  float       timeBetweenAttack;
    public  GameObject  projectTile;
    private bool        bAlreadyAttacked;

    // currentState
    public float    sightRange;
    public float    attackRange;
    public bool     bPlayerInSightRange;
    public bool     bPlayerInAttackRange;

    private void Awake()
    {
        enemyAgent  = GetComponent<NavMeshAgent>();
        playerTrm   = GameObject.Find("PlayerOrigin").transform;
    }

    private void OnEnable()
    {
        GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();
    }

    void Update()
    {
        // 시아, 공격 거리 체크 로직
        bPlayerInSightRange     = Physics.CheckSphere(transform.position, sightRange,   whatIsPlayer);
        bPlayerInAttackRange    = Physics.CheckSphere(transform.position, attackRange,  whatIsPlayer);
        
        //if(bPlayerInAttackRange)
        //{
        //    // 공격
        //    AttackPlayer();
        //}
        //else if(bPlayerInSightRange)
        //{
        //    // 추적
        //    ChasePlayer();
        //}
        //else
        //{
        //    // 페트롤
        //    Patrolling();
        //}

        if(!bPlayerInSightRange && !bPlayerInAttackRange)
        {
            Patrolling();
        }
        if(bPlayerInSightRange)
        {
            ChasePlayer();
        }
        if(bPlayerInAttackRange)
        {
            AttackPlayer();
        }
    }

    private void Patrolling()
    {
        if (!bWalkPointSet) SearchWalkPoint();

        if (bWalkPointSet)
        {
            enemyAgent.SetDestination(walkPoint);
        }

        Vector3 distToWalkPoint = transform.position - walkPoint;
        if(distToWalkPoint.magnitude < 1.0f)
        {
            bWalkPointSet = false;
        }
    }

    private void ChasePlayer()
    {
        enemyAgent.SetDestination(playerTrm.position);
    }

    private void AttackPlayer()
    {
        enemyAgent.SetDestination(transform.position);

        transform.LookAt(playerTrm);
        if(!bAlreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectTile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward   * 32.0f,    ForceMode.Impulse);
            rb.AddForce(transform.up        * 8.0f,     ForceMode.Impulse);

            Destroy(rb.gameObject, 1.0f);

            bAlreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }

    private void ResetAttack()
    {
        bAlreadyAttacked = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // walkPoint가 길인지 아닌지
        if (Physics.Raycast(walkPoint, -transform.up, 2.0f, whatIsGround))
        {
            bWalkPointSet = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
