using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaCTarget : MonoBehaviour {
    PointAndClickMove myPaC;
    private void Start() {
        myPaC = GetComponent<PointAndClickMove>();
    }

    void Update() {
        Vector3 newTarget = Vector3.zero;
        RaycastHit hit;
        if (Input.GetMouseButton(0)) {
            Debug.Log("I Click mouse you fuck why you no move fucker");
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
                Debug.Log(hit);
                newTarget = hit.point;
                myPaC.UpdateTarget(newTarget);
            }
        }
    }
}
