using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PaCTarget : MonoBehaviour {

    PointAndClickMove myPaC;
    LayerMask mask;
    public bool canWalk;
    public bool inputEnabled = true;

  //  public Texture2D cursorTextureWalkable;
  //  public Texture2D cursorTextureNotWalkable;
  //  public CursorMode cursorMode = CursorMode.Auto;
  //  public Vector2 hotSpot = Vector2.zero;

    private void Start() {
        mask = LayerMask.GetMask("Walkable");
        myPaC = GetComponent<PointAndClickMove>();
        canWalk = true;
    }

    void Update()
    {
        //CursorChange();
        Vector3 newTarget = Vector3.zero;
        RaycastHit hit;
        if (Input.GetMouseButton(0) && inputEnabled == true) {
            Debug.Log("Moving to new target");

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask))
            {
                var raycastHit = hit;
                newTarget = hit.point;
                if (canWalk)
                {
                    myPaC.UpdateTarget(newTarget);
                }
            }
         }
    }

    /*
    void CursorChange ()
    {
        bool isWalkable;

        RaycastHit hitPoint;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitPoint, Mathf.Infinity, mask);
        Vector3 myHitPoint = hitPoint.point;
     
        NavMeshHit hit;
        if (NavMesh.SamplePosition(myHitPoint, out hit, 5f, mask))
        {
            isWalkable = true;
        }
        else
        {
            isWalkable = false;
        }

        if (isWalkable)
        {
            Debug.Log("Is walkable...");
            Cursor.SetCursor(cursorTextureWalkable, hotSpot, cursorMode);
        }
        else 
        {
            Debug.Log("Is not walkable...");
            Cursor.SetCursor(cursorTextureNotWalkable, hotSpot, cursorMode);
        }

    }
    */
}