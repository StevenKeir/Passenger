using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionToPlayer : MonoBehaviour {
    GameObject player;
    public Vector3 offSet;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        
	}
	
	// Update is called once per frame
	void Update () {
       // transform.position = player.transform.position + offSet;
	}
}
