using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {

    //[Header("Inventory Script")]
    
    public StatsHandler statHandler;
    public enum Items { Gun, DuctTape, Laptop, CigarBox, Crystal, OxygenKit }
    public Items myItem;
    string itemString;
    public InventoryItem inventoryItem;
    public Inventory invScript;


    public void Start()
    {
        itemString = myItem.ToString();

        
        //statHandler = GameObject.FindGameObjectWithTag("StatHandler").GetComponent<StatsHandler>();
    }

    public void Update()
    {
        if(statHandler == null)
        {
            statHandler = GameObject.FindGameObjectWithTag("StatHandler").GetComponent<StatsHandler>();
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("interacted");
            statHandler.AddItem(itemString, true);
            Interact();
        }
    }

    public void Interact()
    {
        print("interacted");




    }

}
