using UnityEngine;
using UnityEngine.AI;

public class PlayerPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float remainDistMin = 1.0f;

    private int destIndex = 0;
    private NavMeshAgent playerAgnet;

    void Start()
    {
        playerAgnet = GetComponent<NavMeshAgent>();
        if (playerAgnet != null)
        {
            playerAgnet.autoBraking = false;

            GotoNextPoint();
        }
    }

    void Update()
    {
        // pathPending
        // ����������� ���� �غ� ���� ���� ���
        // == ��� �Ϸ� ���¶�� ���� ��θ� ����϶�� ��

        if(!playerAgnet.pathPending && playerAgnet.remainingDistance <= remainDistMin)
        {
            GotoNextPoint();
        }
    }

    private void GotoNextPoint()
    {
        if(patrolPoints.Length == 0) // ����ó��
        {
            Debug.LogError("���� ��ġ�� �����ϴ�. ���� 1�� �̻��� �ʿ��մϴ�.");

            enabled = false;
            return;
        }

        playerAgnet.destination = patrolPoints[destIndex++ % patrolPoints.Length].position;

        //playerAgnet.destination = patrolPoints[destIndex].position;
        //destIndex = (destIndex + 1) % patrolPoints.Length;

    }
}
