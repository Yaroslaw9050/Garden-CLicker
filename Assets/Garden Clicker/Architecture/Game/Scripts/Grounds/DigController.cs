using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundSetting))]
public class DigController : MonoBehaviour
{
    public int DigCounter { get => digCounter;}

    [SerializeField] private int digCounter;
    [SerializeField] private GameObject ghostGround;

    private int currentStep;

    private GroundSetting groundSetting;
    private AppearanceObject appearanceObject;

    private void Awake()
    {
        groundSetting = gameObject.GetComponent<GroundSetting>();
        appearanceObject = GetComponentInChildren<AppearanceObject>();
    }
    public bool Digging()
    {
        if (digCounter < groundSetting.NeedClickCounter)
        {
            digCounter++;
            CheckEndStep();
            return false;
        }
        else
        {
            ghostGround.SetActive(false);
            return true;
        }
    }
    private void CheckEndStep()
    {
        if(digCounter >= currentStep + groundSetting.Steps)
        {
            currentStep += groundSetting.Steps;
            appearanceObject.EndStep();
        }
    }
    public int GetNeedClick()
    {
        return groundSetting.NeedClickCounter;
    }
    public void ResetToDefault()
    {
        ghostGround.SetActive(true);
        appearanceObject.ResetPosition();
        currentStep = 0;
        digCounter = 0;
    }
}
