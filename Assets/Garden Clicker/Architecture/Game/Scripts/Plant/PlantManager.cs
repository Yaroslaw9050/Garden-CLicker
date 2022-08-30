using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public static PlantManager Instance;
    [SerializeField] private PlantType plantType;

    private int costCoefficient = 5;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    public int GetPlantType()
    {
        return (int)plantType;
    }
    public int GetPlantCostType()
    {
        return (int)plantType * costCoefficient;
    }
}
