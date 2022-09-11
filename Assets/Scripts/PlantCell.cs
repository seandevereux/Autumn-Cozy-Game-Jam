using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCell : MonoBehaviour
{
    public bool canHarvest;
    public string plantName;
    public event Action onGetPlant;

    public float growthTime;

    public bool hasActivePlant = false;

    public GameObject visibleGameObject;

    public GameObject seedlingStageObject;
    public GameObject buddingStageObject;
    public GameObject floweringStageObject;
    public GameObject bloomingStageObject;
    public GameObject finishedStageObject;

    void Start()
    {
        hasActivePlant = false;
    }

    public void SetVariables(ScriptablePlants so, PlantDefinitions.PlantType plantType, PlantDefinitions.plantGrowthDifficulty growthDifficulty)
    {
        if (visibleGameObject != null)
            return;

        plantName = so.prefabName;
        // will maybe move this method to plantDefinitions
        if (plantType != PlantDefinitions.PlantType.Empty)
        {
            seedlingStageObject = so.seedlingStageObject;
            buddingStageObject = so.buddingStageObject; 
            floweringStageObject = so.floweringStageObject;
            bloomingStageObject = so.bloomingStageObject;
            finishedStageObject = so.finishedStageObject;
            hasActivePlant = true;
            if(visibleGameObject != null)
            {
                Destroy(visibleGameObject);
            }    
            visibleGameObject = Instantiate(seedlingStageObject, transform.position, Quaternion.identity);
            visibleGameObject.transform.SetParent(transform);
            if(onGetPlant != null)
            {
                Debug.Log("Invoking");
                onGetPlant();
            }
            
        } else if (plantType == PlantDefinitions.PlantType.Empty)
        {
            seedlingStageObject = so.seedlingStageObject;
            buddingStageObject = so.buddingStageObject;
            floweringStageObject = so.floweringStageObject;
            bloomingStageObject = so.bloomingStageObject;
            finishedStageObject = so.finishedStageObject;
            hasActivePlant = false;
            if (onGetPlant != null)
            {
                Debug.Log("Invoking");
                onGetPlant();
            }
        }

        if(growthDifficulty == PlantDefinitions.plantGrowthDifficulty.Easy)
        {
            growthTime = 1f;
        } else if (growthDifficulty == PlantDefinitions.plantGrowthDifficulty.Medium)
        {
            growthTime = 2f;
        }
        else if(growthDifficulty == PlantDefinitions.plantGrowthDifficulty.Hard)
        {
            growthTime = 15f;
        }
        else if(growthDifficulty == PlantDefinitions.plantGrowthDifficulty.Elite)
        {
            growthTime = 20f;
        } 
    }

    public void UpdateVisibleGameObject(GameObject gameObject)
    {
        if(visibleGameObject != null)
        {
            Destroy(visibleGameObject);
            visibleGameObject = Instantiate(gameObject, transform.position, Quaternion.identity);
            visibleGameObject.transform.SetParent(transform);
            return;
        }
        
        visibleGameObject = Instantiate(gameObject, transform.position, Quaternion.identity);
        visibleGameObject.transform.SetParent(transform);
    }
}
