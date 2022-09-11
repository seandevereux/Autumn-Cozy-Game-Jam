using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plants", menuName = "ScriptableObjects/Plants", order = 1)]
public class ScriptablePlants : ScriptableObject
{   
    public string prefabName;
    public PlantDefinitions.PlantType plantType;
    public PlantDefinitions.plantGrowthDifficulty plantGrowthDifficulty;
    public GameObject seedlingStageObject;
    public GameObject buddingStageObject;
    public GameObject floweringStageObject;
    public GameObject bloomingStageObject;
    public GameObject finishedStageObject;
}
