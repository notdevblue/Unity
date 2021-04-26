using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// �� ��ũ��Ʈ ���̸� �ڵ����� NavMeshAgent ����
[RequireComponent(typeof(NavMeshAgent))]
public class MoveAgent : MonoBehaviour
{
    public Transform wayPointGroup;
    // <> <== C#���� ���׸� (C++ == Template)
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
        // ������ �ٰ��� ���� �ڵ����� �ӵ� ���̴� �ɼ� = false;
    }

    void Start()
    {
        wayPointGroup.GetComponentsInChildren<Transform>(wayPoints); // �ڱ� �ڽŵ� ������
        wayPoints.RemoveAt(0); // <= �θ��� �� ����
        MoveWayPoint();
    }

    private void MoveWayPoint()
    {
        // isPathStale == ��� �غ� �� �Ǿ������� true
        if (agent.isPathStale) return;
        agent.destination = wayPoints[nextIndex].position;
        agent.isStopped = false; // ������Ʈ on
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
