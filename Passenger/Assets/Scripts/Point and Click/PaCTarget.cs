using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaCTarget : MonoBehaviour {
    PointAndClickMove myPaC;
    LayerMask mask;
    public bool canWalk;
    private void Start() {
        mask = LayerMask.GetMask("Map");
        myPaC = GetComponent<PointAndClickMove>();
        canWalk = true;
    }

    void Update() {
        Vector3 newTarget = Vector3.zero;
        RaycastHit hit;
        if (Input.GetMouseButton(0)) {
            //Debug.Log("I Click mouse you fuck why you no move fucker");
            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask)) {
                Debug.Log(hit);
                newTarget = hit.point;
                if (canWalk)
                {
                    myPaC.UpdateTarget(newTarget);
                }
            }
        }
    }
}
