using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
#if true
    private NavMeshAgent playerAgent;
    public List<Vector3> partrolPos;
    private int destIndex = 0;
    void Start()
    {
        partrolPos = new List<Vector3>();
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseInput();

        if(Input.GetMouseButtonDown(1))
        {
            playerAgent.destination = partrolPos[destIndex++ % partrolPos.Count];
            Debug.Log(playerAgent.destination);
        }
    }


    void MouseInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            partrolPos.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
#endif
#if false
    NavMeshAgent playerAgent;
    RaycastHit hitInfo = new RaycastHit();

    private void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                Debug.Log(hitInfo.point);
                playerAgent.destination = hitInfo.point;
            }
        }
    }
#endif

}
