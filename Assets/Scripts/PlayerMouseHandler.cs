using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseHandler : MonoBehaviour
{
    public ScriptablePlants plants;
    public ScriptablePlants plantsb;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.transform.CompareTag("PlantCell"))
            {
                Debug.Log("Hit, " + hit.transform.name);
                hit.transform.GetComponent<PlantCell>().SetVariables(plants, plants.plantType, plants.plantGrowthDifficulty);
            } else
            {
                Debug.Log("Hit, " + hit.transform.name);
            }
        }     
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.transform.CompareTag("PlantCell"))
            {
                Debug.Log("Hit, "  + hit.transform.name);
                hit.transform.GetComponent<PlantCell>().SetVariables(plantsb, plantsb.plantType, plantsb.plantGrowthDifficulty);
            }
            else
            {
                Debug.Log("Hit, " + hit.transform.name);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.transform.CompareTag("Item")) 
            {
                Debug.Log("Hit, " + hit.transform.name);
                hit.transform.TryGetComponent<ItemObject>(out ItemObject item);
                item.OnHandlePickupItem();
            }
            else
            {
                Debug.Log("Hit, " + hit.transform.name);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectItem.current.SelectItemInSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectItem.current.SelectItemInSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectItem.current.SelectItemInSlot(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectItem.current.SelectItemInSlot(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectItem.current.SelectItemInSlot(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectItem.current.SelectItemInSlot(6);
        }
    }
}
