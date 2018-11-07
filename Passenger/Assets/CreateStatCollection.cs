using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStatCollection : MonoBehaviour {
    public GameObject myStatHandler;
    private void Start() {
        if (GameObject.FindGameObjectWithTag("StatHandler") == null) {
            Instantiate(myStatHandler, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
