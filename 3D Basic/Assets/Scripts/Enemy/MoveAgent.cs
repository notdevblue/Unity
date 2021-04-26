using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// 이 스크립트 붙이면 자동으로 NavMeshAgent 붙음
[RequireComponent(typeof(NavMeshAgent))]
public class MoveAgent : MonoBehaviour
{
    public Transform wayPointGroup;
    // <> <== C#에선 제네릭 (C++ == Template)
    private List<Transform> wayPoints = new List<Transform>();

    public int nextIndex = 0;
    private NavMeshAgent agent;

    private readonly float patrolSpeed = 1.5f;
    private readonly float traceSpeed = 4.0f;
    private bool _patrolling;
    public bool patrolling
    {
        get { return _patrolling; }
        set
        {
            _patrolling = value;
            if (_patrolling)
            {
                agent.speed = patrolSpeed;
                MoveWayPoint();
            }
        }
    }

    private Vector3 _traceTarget;
    public Vector3 traceTarget
    {
        get { return _traceTarget; }
        set
        {
            _traceTarget = value;
            agent.speed = traceSpeed;
            TraceTarget(_traceTarget);
        }
    }

    private void TraceTarget(Vector3 pos)
    {
        if (agent.isPathStale) return;
        agent.destination = pos;
        agent.isStopped = false;
    }

    public void Stop()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
        _patrolling = false;
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        // 목적지 다가갈 수록 자동으로 속도 줄이는 옵션 = false;
    }

    void Start()
    {
        wayPointGroup.GetComponentsInChildren<Transform>(wayPoints); // 자기 자신도 가져옴
        wayPoints.RemoveAt(0); // <= 부모의 것 삭제
        MoveWayPoint();
    }

    private void MoveWayPoint()
    {
        // isPathStale == 경로 준비 안 되어있으면 true
        if (agent.isPathStale) return;
        agent.destination = wayPoints[nextIndex].position;
        agent.isStopped = false; // 에이전트 on
    }

    private void Update()
    {
        if (!_patrolling) return;

        if(agent.velocity.sqrMagnitude >= 0.04f && agent.remainingDistance <= 0.5f)
        {
            nextIndex = (++nextIndex) % wayPoints.Count; // 0 1 2 3 0 1 2 3 0 1 2 3...
            MoveWayPoint();
        }
    }
}
