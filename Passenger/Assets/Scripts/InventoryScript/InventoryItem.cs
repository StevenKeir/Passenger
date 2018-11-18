using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Item",menuName = "Inventory/Item",order = 1)]
public class InventoryItem : ScriptableObject
{
    public string objectName = "Item";
    public Sprite icon;
}