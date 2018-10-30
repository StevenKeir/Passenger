using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    void OnMouseOver()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            print("interacted");
            Interact();
        }
    }

    void Interact()
    {

    }

}
