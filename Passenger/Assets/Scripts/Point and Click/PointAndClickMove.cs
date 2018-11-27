using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClickMove : MonoBehaviour {

    public NavMeshAgent myAgent;

    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start() {
        myAgent = GetComponent<NavMeshAgent>();
    }

    public void UpdateTarget(Vector3 target) {
        myAgent.destination = target;
        animator.SetBool("Walk", true);
    }
}