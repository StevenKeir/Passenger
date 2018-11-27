using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
public class AnimationMovement : MonoBehaviour {

    public NavMeshAgent myNMA;
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
       if (myNMA.remainingDistance < myNMA.radius)
        {
            animator.SetBool("Walk", true);
        }

    }
}
