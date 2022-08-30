using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class WorkSetting : MonoBehaviour
{
    public int NeedClickCounter
    {
        get
        {
            return requiredClick * coefficient;
        }
        set
        {
            if (value < 0) return;
            requiredClick = value;
        }
    }
    public int Steps
    {
        get
        {
            return (requiredClick * coefficient) / steps;
        }
    }
    [SerializeField] protected int requiredClick;
    [SerializeField] protected int steps;
    protected int coefficient;

    private void Awake()
    {
        CheckTestMode();
    }
    private void Start()
    {
        
        coefficient = PlantManager.Instance.GetPlantType();
        if (coefficient <= 0) coefficient = 1;
        
    }

    private void CheckTestMode()
    {
        if(TestSystemManager.Instance.TestMode)
        {
            NeedClickCounter = 10;
            coefficient = 1;
            steps = 5;
        }
    }
}
