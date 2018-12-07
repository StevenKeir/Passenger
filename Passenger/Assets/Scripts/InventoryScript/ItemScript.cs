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
    public Texture2D defaultCursor;
    public Texture2D grabCursor;
    public Vector2 cursorHotspot = new Vector2(0, 0);

    private void EarlyStart()
    {
        if (Oxygenkit == null)
        {
            Oxygenkit = GameObject.FindGameObjectWithTag("OxygenKit");
        }
        if (invScript == null)
        {
            invScript = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<Inventory>();
        }
        if(paused == null)
        {
            paused = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<PauseMenu>();
        }
        Cursor.SetCursor(defaultCursor, cursorHotspot, CursorMode.Auto);
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
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !paused.paused)
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

    private void OnMouseEnter()
    {
        Cursor.SetCursor(grabCursor, cursorHotspot, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor, cursorHotspot, CursorMode.Auto);
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
