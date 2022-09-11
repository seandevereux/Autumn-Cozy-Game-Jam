using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject inventoryPanel;
    public event Action onInventoryChangedEvent;
    public static InventorySystem current { get; private set; }
    public Dictionary<InventoryItemData, InventoryItem> itemDictionary;
    public List<InventoryItem> inventory { get; private set; }

    private void Start()
    {
        if(current != null && current != this)
        {
            Destroy(this);
        }
        current = this;
        inventory = new List<InventoryItem>();
        itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
        inventoryPanel.SetActive(true);
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if(itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
         return null;
    }

    public void Add(InventoryItemData referenceData)
    {
        if(itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            
            value.AddToStack();
            onInventoryChangedEvent();
            Debug.Log("Invoking Add");
            
        } else
        {
            
            
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            itemDictionary.Add(referenceData, newItem);
            
            onInventoryChangedEvent();
        }

    }
    public void Remove(InventoryItemData referenceData)
    {
        if(itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            if (onInventoryChangedEvent != null)
            {
                onInventoryChangedEvent();
            }
            value.RemoveFromStack();
        }
        if(value.stackSize == 0)
        {
            if (onInventoryChangedEvent != null)
            {
                onInventoryChangedEvent();
            }
            inventory.Remove(value);
            itemDictionary.Remove(referenceData);
        }
    }

}
