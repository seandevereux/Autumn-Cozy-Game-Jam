using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item Data")]
public class InventoryItemData : ScriptableObject
{

    public string id;
    public string itemName;
    public string description;
    public Sprite icon;
    public GameObject prefab;
    public ScriptablePlants plants;
}
