using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnScript : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		/*if (target) {
			Transform.LookAt(target.transform);
		}*/

	}


	void GetTarget () {
		target = GameObject.FindGameObjectWithTag("Enemy");
	}
}
