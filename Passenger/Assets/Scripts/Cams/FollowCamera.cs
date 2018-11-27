using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

	public GameObject target;
	public float damping = 1;
	Vector3 offset;

	//public FirstPersonController playerController = null;
	//public TopDownController tdController = null;

	void Start() {
		offset = target.transform.position - transform.position;
	}

	void LateUpdate() {
		float currentAngle = transform.eulerAngles.y;
		float desiredAngle = target.transform.eulerAngles.y;
		float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

		Quaternion rotation = Quaternion.Euler(0, angle, 0);
		transform.position = target.transform.position - (rotation * offset);

		transform.LookAt(target.transform);
	}

	void Update (){

		if (Input.GetButton ("Fire3")) {
			damping = 5;
		} else {
			damping = 2;
		}

		/*if (Input.GetButton ("Fire3")) {
			playerController.inputEnabled = false;
		} else {
			playerController.inputEnabled = true;
		}*/
	}

}
