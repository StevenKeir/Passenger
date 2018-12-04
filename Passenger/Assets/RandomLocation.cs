using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocation : MonoBehaviour {

    public GameObject[] mySpawns;
	void Start () {
        transform.position = mySpawns[Random.Range(0, mySpawns.Length)].transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.12f, transform.position.z);
	}

}
