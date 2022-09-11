using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDefinitions : MonoBehaviour
{
    public enum plantGrowthDifficulty
    {
        Easy,
        Medium,
        Hard,
        Elite
    }
    public plantGrowthDifficulty difficulty;

    public static PlantDefinitions Instance;
    public enum PlantType
    {
        Empty,
        Pumpkin,
        Wheat,
        Potato,
        Carrot,
        Strawberry,
        Onion,
        GreenBeans,
        Turnip,
        Blueberries,
        Raspberries
    }
    public PlantType plantType;

    private void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(Instance);
        } else if (Instance == null)
        {
            Instance = this;
        }
        
    }

    public PlantDefinitions GetInstance()
    {
        return Instance;
    }
}
