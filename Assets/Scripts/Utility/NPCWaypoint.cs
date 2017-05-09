using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCWaypoint : MonoBehaviour {

    public NavMeshAgent targetAgent;

    public void Activate()
    {
        targetAgent.destination = transform.position;
    }
}
