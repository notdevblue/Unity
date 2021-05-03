using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAgent : MonoBehaviour
{
    [SerializeField] Transform goalTrm;

    void Start()
    {
        NavMeshAgent playerAgnet = GetComponent<NavMeshAgent>();
        if(playerAgnet != null)
        {
            playerAgnet.destination = goalTrm.position;
        }    
    }
}
