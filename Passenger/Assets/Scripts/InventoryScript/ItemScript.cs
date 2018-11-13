using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {

    [Header("Inventory Script")]
    public Inventory inventoryScript;

    public void Awake()
    {
        if (inventoryScript == null)
        {
            inventoryScript = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("interacted");
            inventoryScript.Interact();
        }
    }

}
