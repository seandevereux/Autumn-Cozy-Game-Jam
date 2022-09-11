using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
    private InventoryManager inventoryManager;
    public static SelectItem current;

    private void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
        if (current != null && current != this)
        {
            Destroy(this);
        }
        current = this;
    }
    public void SelectItemInSlot(int slot)
    {
        List<GameObject> tempInv = new List<GameObject> ();
        tempInv = inventoryManager.inventory.Where(item => item != null).ToList();
        if(slot < tempInv.Count)
        {
            tempInv[slot].GetComponent<Slot>().Select();
            Debug.Log(tempInv[slot].GetComponent<Slot>().gameObject.name); 
        }    

    }
}
