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
        // 계산중이지만 아직 준비가 되지 않은 경로
        // == 계산 완료 상태라면 다음 경로를 계산하라는 것

        if(!playerAgnet.pathPending && playerAgnet.remainingDistance <= remainDistMin)
        {
            GotoNextPoint();
        }
    }

    private void GotoNextPoint()
    {
        if(patrolPoints.Length == 0) // 예외처리
        {
            Debug.LogError("순찰 위치가 없습니다. 최초 1개 이상이 필요합니다.");

            enabled = false;
            return;
        }

        playerAgnet.destination = patrolPoints[destIndex++ % patrolPoints.Length].position;

        //playerAgnet.destination = patrolPoints[destIndex].position;
        //destIndex = (destIndex + 1) % patrolPoints.Length;

    }
}
