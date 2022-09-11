using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    public List<GameObject> inventory;
    [SerializeField]
    GameObject _slotPrefab;
    // Start is called before the first frame update

    private void Start()
    {
        InventorySystem.current.onInventoryChangedEvent += OnUpdateInventory;
    }
    private void OnDisable()
    {
        InventorySystem.current.onInventoryChangedEvent -= OnUpdateInventory;
    }

    private void OnUpdateInventory()
    {
        
        foreach(Transform t in transform)
        {
            
            Destroy(t.gameObject);
        }
        DrawInventory();
    }

    private void DrawInventory()
    {
        foreach (InventoryItem item in InventorySystem.current.inventory)
        {
            AddInventorySlot(item);
        }
    }

    private void AddInventorySlot(InventoryItem item)
    {
        Debug.Log("Drawing inventory...");
        GameObject obj = Instantiate(_slotPrefab);
        obj.transform.SetParent(transform, false);
        inventory.Add(obj);

        Slot slot = obj.GetComponent<Slot>();
        slot.Set(item);
        
    }
}
