using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClickMove : MonoBehaviour
{

    public NavMeshAgent myAgent;

    public Animator animator;
    public float stoppingVelocity = 0.01f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (myAgent.velocity.magnitude < stoppingVelocity) //(myAgent.remainingDistance < myAgent.radius) ||
        {
            if (animator != null)
            animator.SetBool("Walk", false);
        }
   
    }

    public void UpdateTarget(Vector3 target)
    {
        myAgent.destination = target;
        if (myAgent.remainingDistance > myAgent.radius)
        {
            animator.SetBool("Walk", true);
        }
    }
}