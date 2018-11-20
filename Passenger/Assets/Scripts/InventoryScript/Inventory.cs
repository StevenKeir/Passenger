using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    [Header("Iventory Items")]
    public List<InventoryItem> items;
    [SerializeField] Transform itemParent;
    [SerializeField] ItemSlot[] itemslots;
    [Header("Items to add to inventory")]
    [SerializeField] InventoryItem[] allItemsToAdd = new InventoryItem[5];
    public StatsHandler statHandler;
    public bool gun;
    public bool laptop;
    public bool crystal;
    public bool ductape;
    public bool cigarbox;

    private void Update()
    {
        if(itemParent != null)
        {
            itemslots = itemParent.GetComponentsInChildren<ItemSlot>();
        }
        RefreshUI();
    }

    public void LateUpdate()
    {
        if (statHandler == null)
        {
            statHandler = GameObject.FindGameObjectWithTag("StatHandler").GetComponent<StatsHandler>();
        }
        Items();
    }

    private void RefreshUI()
    {
        int i = 0;
        for (; i < items.Count && i < itemslots.Length; i++)
        {
            itemslots[i].item = items[i];
        }

        for (; i < itemslots.Length; i++)
        {
            itemslots[i].item = null;
        }

    }
    public void Items()
    {
        if (statHandler.hasGun == true && gun == false)
        {
            items.Add(allItemsToAdd[3]);
            gun = true;
        }
        if (statHandler.hasCrystal == true && crystal == false)
        {
            items.Add(allItemsToAdd[1]);
            crystal = true;
        }
        if (statHandler.hasLaptop == true && laptop == false)
        {
            items.Add(allItemsToAdd[4]);
            laptop = true;
        }
        if (statHandler.hasCigarBox == true && cigarbox == false)
        {
            items.Add(allItemsToAdd[0]);
            cigarbox = true;
        }
        if (statHandler.hasDuctape == true && ductape == false)
        {
            items.Add(allItemsToAdd[2]);
            ductape = true;
        }
    }
}
