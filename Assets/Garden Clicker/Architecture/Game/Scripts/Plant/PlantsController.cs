using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlantsSetting))]
public class PlantsController : MonoBehaviour
{
    public int PlantsCounter { get => plantsCounter; }

    [SerializeField] private int plantsCounter;
    [SerializeField] private List<GameObject> plantTypesPrefab;
    [SerializeField] private Transform spawnPosition;

    private PlantsSetting plantsSetting;
    [SerializeField] private DefaultVisualiser visualiser;
    private GameObject plant;

    private int currentStep;
    private bool isVisualSpawn;

    private void Awake()
    {
        plantsSetting = gameObject.GetComponent<PlantsSetting>();
    }

    public bool PlantsPlant()
    {
        if(!isVisualSpawn)
        {
            CreateVisualPlant();
            isVisualSpawn = !isVisualSpawn;
        }
        if (plantsCounter < plantsSetting.NeedClickCounter)
        {
            plantsCounter++;
            CheckEndStep();
            return false;
        }
        else
        {
            return true;
        }
    }
    private void CheckEndStep()
    {
        if (plantsCounter >= currentStep + plantsSetting.Steps)
        {
            currentStep += plantsSetting.Steps;
            visualiser.Visualise();
        }
    }
    private void CreateVisualPlant()
    {
        plant = Instantiate(plantTypesPrefab[PlantManager.Instance.GetPlantType() -1], spawnPosition);
        visualiser = plant.GetComponent<DefaultVisualiser>();
    }
    public int GetNeedClick()
    {
        return plantsSetting.NeedClickCounter;
    }
    public void ResetToDefault()
    {
        isVisualSpawn = false;
        plantsCounter = 0;
        currentStep = 0;
        visualiser = null;

        if(plant != null)
        Destroy(plant);

    }
}
