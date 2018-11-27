using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour {

    //[Header("Inventory Script")]
    
    public StatsHandler statHandler;
    public enum Items { Gun, DuctTape, Laptop, CigarBox, Crystal, OxygenKit }
    public Items myItem;
    string itemString;
    public InventoryItem inventoryItem;
    public Inventory invScript;
    public GameObject Oxygenkit;

    private void Awake()
    {
        if (Oxygenkit == null)
        {
            Oxygenkit = GameObject.FindGameObjectWithTag("OxygenKit");
        }
        if (invScript == null)
        {
            invScript = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        }
    }

    public void Start()
    {
        itemString = myItem.ToString();
        Oxygenkit.SetActive(false);         //Sets to false so the player can pickup later in the game.
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
            //print("interacted");
            statHandler.AddItem(itemString, true);
            Interact();
            if(myItem == Items.OxygenKit)
            {
                OxygenUI();
            }

            Destroy(this.gameObject);
        }
    }

    public void Interact()
    {
       // print("interacted");
        

    }

    void OxygenUI()
    {
        Oxygenkit.SetActive(true);        
    }

}
