using UnityEngine;

[RequireComponent(typeof(FinanceRepository))]
[RequireComponent(typeof(UIFinanceUpdater))]

public class FinanceController : MonoBehaviour
{
    public static FinanceController Instance;
    private FinanceRepository finance;
    private UIFinanceUpdater uiFinanceUpdater;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        finance = gameObject.GetComponent<FinanceRepository>();
        uiFinanceUpdater = gameObject.GetComponent<UIFinanceUpdater>();
    }
    private void Start()
    {
        uiFinanceUpdater.UpdateUIValue(finance.PlayerMoney);
    }
    public void AddMoney(long value)
    {
        if (value <= 0) return;
        finance.PlayerMoney += value;
        finance.SaveMoneyData();
        uiFinanceUpdater.UpdateUIValue(finance.PlayerMoney,true);
    }
    public void RemoveMoney(long value)
    {
        if (value <= 0) return;
        finance.PlayerMoney -= value;
        finance.SaveMoneyData();
        uiFinanceUpdater.UpdateUIValue(finance.PlayerMoney, false);
    }
}
