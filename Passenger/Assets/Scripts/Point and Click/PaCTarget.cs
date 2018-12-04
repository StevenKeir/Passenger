using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PaCTarget : MonoBehaviour {

    PointAndClickMove myPaC;
    LayerMask mask;
    public bool canWalk;
    public bool inputEnabled = true;


    private void Start() {
        mask = LayerMask.GetMask("Map");
        myPaC = GetComponent<PointAndClickMove>();
        canWalk = true;
    }

    void Update() {
        CursorChange();
        Vector3 newTarget = Vector3.zero;
        RaycastHit hit;
        if (Input.GetMouseButton(0) && inputEnabled == true) {
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

    void CursorChange()
    {
        Vector3 rayPos;
        RaycastHit hit2;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit2, Mathf.Infinity, mask))
        {
            rayPos = hit2.point;
            NavMeshHit hit;
            NavMesh.SamplePosition(rayPos, out hit, float.MaxValue, 1 << NavMesh.AllAreas);
            if ((hit2.point.x >= hit.position.x - 0.05f) &&
                (hit2.point.x <= hit.position.x + 0.05f) &&
                (hit2.point.y >= hit.position.y - 0.05f) &&
                (hit2.point.y <= hit.position.y + 0.05f) &&
                (hit2.point.z >= hit.position.z - 0.05f) &&
                (hit2.point.z <= hit.position.z + 0.05f))
            {
                Debug.Log("Walking possible");
                //cursor change to walk
            }
            else
            {
                Debug.Log("not possible");
                //cursor change to normal
            }
        }
    }
}
