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
    public PauseMenu paused;

    public Vector2 cursorHotspot = new Vector2(0, 0);
    public Transform player;
    public float distance;

    private void EarlyStart()
    {

        if (invScript == null)
        {
            invScript = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<Inventory>();
        }
        if(paused == null)
        {
            paused = GameObject.FindGameObjectWithTag("Inventory").GetComponentInChildren<PauseMenu>();
        }
    }

    public void Start()
    {
        EarlyStart();
        itemString = myItem.ToString();
        Oxygenkit.SetActive(false);         //Sets to false so the player can pickup later in the game.
    }

    public void Update()
    {
        if(statHandler == null)
        {
            statHandler = GameObject.FindGameObjectWithTag("StatHandler").GetComponent<StatsHandler>();
        }
        if (Oxygenkit == null)
        {
            Oxygenkit = GameObject.FindGameObjectWithTag("OxygenKit");
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;

       distance = Vector3.Distance(this.transform.position, player.transform.position);
    }


    void OnMouseOver()
    {

        if (distance <= 1.25f)
        {
            if (Input.GetMouseButtonDown(0) && !paused.paused)
            {
                //print("interacted");
                statHandler.AddItem(itemString, true);
                
                if (myItem == Items.OxygenKit)
                {
                    OxygenUI();
                }

                Destroy(this.gameObject);
            }
        }

    }

    void OxygenUI()
    {
        Oxygenkit.SetActive(true);        
    }

}
