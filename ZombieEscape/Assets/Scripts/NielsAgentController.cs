using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NielsAgentController : MonoBehaviour
{
    static Animator animator;
    public NavMeshAgent agent;
    public float seePlayerRadius;
    public float teleportRadius;
    private GameObject player;
    private float playerDistance;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        playerDistance = Vector3.Distance(player.transform.position, transform.position);
        if (playerDistance <= seePlayerRadius)
        {
            animator.SetBool("nielsIsWalking", true);
            agent.SetDestination(player.transform.position);
        }
        else
        {
            animator.SetBool("nielsIsWalking", false);
        }
    }
}
