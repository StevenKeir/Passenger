using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    void OnMouseOver()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            
            Interact();
        }
    }

    public void Interact()
    {
            print("interacted");
    }

}
