using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HarvestingSetting))]
public class HarvestingController : MonoBehaviour
{
    public int HarvestingCounter{ get => harvestCounter; }

    [SerializeField] private int harvestCounter;
    private int currentStep;

    private HarvestingSetting harvestingSetting;
    private DefaultVisualiser visualiser;

    private void Awake()
    {
        harvestingSetting = gameObject.GetComponent<HarvestingSetting>();
    }
    public void SetVisualiser(DefaultVisualiser visualiser)
    {
        this.visualiser = visualiser;
    }

    public bool Harvesting()
    {
        if (visualiser == null)
        {
            visualiser = gameObject.GetComponentInChildren<DefaultVisualiser>();
        }
        if (harvestCounter < harvestingSetting.NeedClickCounter)
        {
            harvestCounter++;
            CheckEndStep();
            return false;
        }
        else return true;
    }
    private void CheckEndStep()
    {
        if (harvestCounter >= currentStep + harvestingSetting.Steps)
        {
            currentStep += harvestingSetting.Steps;
            visualiser.StepHarvesting();
        }
    }
    public int GetNeedClick()
    {
        return harvestingSetting.NeedClickCounter;
    }
    public void ResetToDefault()
    {
        harvestCounter = 0;
        currentStep = 0;
        visualiser = null;
    }
}
