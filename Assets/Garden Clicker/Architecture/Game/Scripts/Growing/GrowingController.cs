using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GrowingSetting))]
public class GrowingController : MonoBehaviour
{
    public int GrowCounter { get => growCounter; }

    [SerializeField] private int growCounter;
    private int currentStep;

    private GrowingSetting growingSetting;
    private DefaultVisualiser visualiser;


    private void Awake()
    {
        growingSetting = gameObject.GetComponent<GrowingSetting>();
    }

    public void SetVisualiser(DefaultVisualiser visualiser)
    {
        this.visualiser = visualiser;
    }

    public bool Growing()
    {
        if(visualiser == null)
        {
            visualiser = gameObject.GetComponentInChildren<DefaultVisualiser>();
        }
        if (growCounter < growingSetting.NeedClickCounter)
        {
            growCounter++;
            CheckEndStep();
            return false;
        }
        else return true;
    }
    private void CheckEndStep()
    {
        if (growCounter >= currentStep + growingSetting.Steps)
        {
            currentStep += growingSetting.Steps;
            visualiser.StepVisualise();
        }
    }
    public int GetNeedClick()
    {
        return growingSetting.NeedClickCounter;
    }
    public void ResetToDefault()
    {
        growCounter = 0;
        currentStep = 0;

        visualiser = null;
    }
}
