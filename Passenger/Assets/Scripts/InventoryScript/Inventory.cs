using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    [Header("Iventory Items")]
    [SerializeField] List<InventoryItem> items;
    [SerializeField] Transform itemParent;
    [SerializeField] ItemSlot[] itemslots;
    [Header("Items to add to inventory")]
    [SerializeField] InventoryItem[] allItemsToAdd = new InventoryItem[5];
    public StatsHandler statHandler;


    private void OnValidate()
    {
        if(itemParent != null)
        {
            itemslots = itemParent.GetComponentsInChildren<ItemSlot>();
        }
        RefreshUI();
    }

    public void Update()
    {
        if (statHandler == null)
        {
            statHandler = GameObject.FindGameObjectWithTag("StatHandler").GetComponent<StatsHandler>();
        }
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
 

    }

}
