using System;
using UnityEngine;

[RequireComponent(typeof(DigController))]
[RequireComponent(typeof(PlantsController))]
[RequireComponent(typeof(GrowingController))]
[RequireComponent(typeof(HarvestingController))]
public class PhaseController : MonoBehaviour, IMainButtonClick
{
    [SerializeField] private int phasa;
    [SerializeField] private int plantCost = 100;
    private DigController digController;
    private PlantsController plantsController;
    private GrowingController growingController;
    private HarvestingController harvestingController;
    private PlaceSellController sellController;

    private UIDeskController deskController;

    private readonly string[] phasaName = { "DIGGING", "PLANT", "GROWING", "HARVESTING"};

    private void Awake()
    {
        digController = gameObject.GetComponent<DigController>();
        plantsController = gameObject.GetComponent<PlantsController>();
        growingController = gameObject.GetComponent<GrowingController>();
        harvestingController = gameObject.GetComponent<HarvestingController>();

        deskController = gameObject.GetComponentInChildren<UIDeskController>();

        sellController = new PlaceSellController(plantCost);

    }
    private void Start()
    {
        ClickEventManager.Instance.OnButtonClick.AddListener(MainButtonClick);
        ResetDataToDefault();
    }
    public void MainButtonClick()
    {
        switch(phasa)
        {

            case 0:
                {
                    if (digController.Digging()) phasa++;
                    deskController.SetDeskParameter(digController.GetNeedClick() + 2, digController.DigCounter, phasaName[0]);
                    break;
                }
           case 1:
                {
                    if(plantsController.PlantsPlant()) phasa++;
                    deskController.SetDeskParameter(plantsController.GetNeedClick(), plantsController.PlantsCounter, phasaName[1]); 
                    break;
                }
           case 2:
                {
                    if (growingController.Growing()) phasa++;
                    deskController.SetDeskParameter(growingController.GetNeedClick(), growingController.GrowCounter, phasaName[2]);
                    break;
                }
           case 3:
                {
                    if (harvestingController.Harvesting()) phasa++;
                    deskController.SetDeskParameter(harvestingController.GetNeedClick(), harvestingController.HarvestingCounter, phasaName[3]);
                    break; 
                }
           default:
                {
                    ResetDataToDefault();
                    FinanceController.Instance.AddMoney(sellController.SellPlant());
                    break;
                }
        }
    }

    private void ResetDataToDefault()
    {
        phasa = 0;
        digController.ResetToDefault();
        plantsController.ResetToDefault();
        growingController.ResetToDefault();
        harvestingController.ResetToDefault();

        deskController.SetDeskParameter(0f, 0f, phasaName[0]);
    }
}
