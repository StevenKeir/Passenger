using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClickMove : MonoBehaviour
{

    public NavMeshAgent myAgent;

    public Animator animator;
    public float stoppingVelocity = 0.01f;

    // targeticon
    public GameObject targetIcon;
    public float targetOffset;
    public float targetRange = .2f;

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

    public void UpdateTargetIcon()
    {
        float dist = Vector3.Distance(targetIcon.transform.position, transform.position);
        if (dist > targetRange)
            ToggleTargetIcon(true);
        else
            ToggleTargetIcon(false);
    }

    public void ToggleTargetIcon(bool isOn)
    {
        if (isOn)
        {
            targetIcon.GetComponent<MeshRenderer>().enabled = true; 
        }
        else
        {
            targetIcon.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void UpdateTarget(Vector3 target)
    {
        myAgent.destination = target;
        if (myAgent.remainingDistance > myAgent.radius)
        {
            animator.SetBool("Walk", true);
        }

        // targeticon
        targetIcon.transform.position = target;
        targetIcon.transform.Translate(Vector3.up * targetOffset);
    }
}