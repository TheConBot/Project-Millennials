using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCWaypoint : MonoBehaviour {

    public NavMeshAgent targetAgent;

    public void Activate()
    {
        targetAgent.destination = transform.position;
        if (targetAgent.transform.GetComponentInChildren<BoxCollider>() != null)
        {
            targetAgent.transform.GetComponentInChildren<BoxCollider>().enabled = false;
        }
    }
}
