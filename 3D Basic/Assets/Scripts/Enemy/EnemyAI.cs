using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyState
    {
        PATROL,
        TRACE,
        ATTACK,
        DIE
    }

    public EnemyState state = EnemyState.PATROL;

    private Transform playerTr;

    public float attackDist = 5.0f;
    public float traceDist = 10.0f;
    public float judgeDelay = 0.3f;
    // 매 프래임마다 판단하면 엄청난 부하 걸림

    public bool isDie = false;
    private WaitForSeconds ws;
    private MoveAgent moveAgent;

    private void Awake()
    {
        moveAgent = GetComponent<MoveAgent>();
        ws = new WaitForSeconds(judgeDelay);
    }

    void Start()
    {
        playerTr = GameManager.instance.playerTr;
    }

    private void OnEnable() // Start 보다 빠름
    {
        StartCoroutine(CheckState());
        StartCoroutine(Action());
    }


    // 자신상태 채크 코루틴
    IEnumerator CheckState()
    {
        while(!isDie)
        {
            if(state == EnemyState.DIE)
            {
                yield break; // 코루틴 깨짐
            }
            if (playerTr == null)
                yield return ws;

            float dist = (playerTr.position - transform.position).sqrMagnitude;

            if (dist <= attackDist * attackDist)
            {
                state = EnemyState.ATTACK;
            }
            else if (dist <= traceDist * traceDist)
            {
                state = EnemyState.TRACE;
            }
            else
            {
                state = EnemyState.PATROL;
            }

            yield return ws;
        }
    }


    // 상태 기반 액션 코루팅
    IEnumerator Action()
    {
        while (!isDie)
        {
            yield return ws;
            switch (state)
            {
                case EnemyState.PATROL:
                    moveAgent.patrolling = true;
                    break;

                case EnemyState.TRACE:
                    moveAgent.traceTarget = playerTr.position;
                    break;

                case EnemyState.ATTACK:
                    moveAgent.Stop();
                    break;

                case EnemyState.DIE:
                    moveAgent.Stop();
                    break;
            }
        }
    }

    void Update()
    {
        
    }
}
