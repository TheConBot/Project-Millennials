using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAnimations : MonoBehaviour {

    private Animator anim;
    private NavMeshAgent agent;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update () {
        anim.SetBool("isIdle", (agent.velocity.magnitude == 0));
        anim.SetBool("isWalking", (agent.velocity.magnitude != 0));
    }
}
