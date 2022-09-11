using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantStateManager : MonoBehaviour
{
    // possible states
    public enum posState
    {
        Empty,
        Seedling,
        Budding,
        Flowering,
        Blooming,
        Grown,
    }
    public posState curState;

    public PlantCell _plantCell;
    
    // Start is called before the first frame update
    void Awake()
    {
        _plantCell = GetComponent<PlantCell>();
    }

    private void OnEnable()
    {
        _plantCell.onGetPlant += CheckForPlant;
    }

    private void OnDisable()
    {
        _plantCell.onGetPlant -= CheckForPlant;
    }
    private void CheckForPlant()
    {
        if(_plantCell.hasActivePlant)
        {
            if(curState == posState.Empty)
            {
                curState = posState.Seedling;
            }
            
            _plantCell.UpdateVisibleGameObject(GetVisibleGameObject());
            StartCoroutine("Grow");

        } else if (!_plantCell.hasActivePlant)
        {
            Debug.Log("Does Not have plant");
        }
    }

    IEnumerator Grow()
    {
        Debug.Log("Does Not have planteee");
        if (curState == posState.Seedling)
        {
            _plantCell.canHarvest = false;
            yield return new WaitForSeconds(_plantCell.growthTime);
            curState = posState.Budding;
        }
        else if (curState == posState.Budding)
        {
            _plantCell.canHarvest = false;
            yield return new WaitForSeconds(_plantCell.growthTime);
            curState = posState.Flowering;
        }
        else if (curState == posState.Flowering)
        {
            _plantCell.canHarvest = false;
            yield return new WaitForSeconds(_plantCell.growthTime);
            curState = posState.Blooming;
        }
        else if (curState == posState.Blooming)
        {
            _plantCell.canHarvest = false;
            yield return new WaitForSeconds(_plantCell.growthTime);
            Notification.Instance.SendNotification(true, "Your " + _plantCell.plantName +  " plant is ready to be harvested");
            curState = posState.Grown;
            
        } else if (curState == posState.Grown)
        {
            _plantCell.canHarvest = true;
        }

        yield return new WaitForSeconds(_plantCell.growthTime);
        _plantCell.UpdateVisibleGameObject(GetVisibleGameObject());
        StartCoroutine("Grow");
    }
    private GameObject GetVisibleGameObject()
    {

        if (curState == posState.Seedling)
        {
            return _plantCell.seedlingStageObject;
        }
        else if (curState == posState.Budding)
        {
            return _plantCell.buddingStageObject;
        }
        else if (curState == posState.Flowering)
        {
            return _plantCell.floweringStageObject;
        }
        else if (curState == posState.Blooming)
        {
            return _plantCell.bloomingStageObject;
        }
        else if (curState == posState.Grown)
        {
            return _plantCell.finishedStageObject;
        }

        return null;
    }
}
