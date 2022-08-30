using System.IO;
using UnityEngine;

public class FinanceRepository : MonoBehaviour
{
    public long PlayerMoney
    {
        get => playerMoney;
        set => playerMoney = value;
    }
    [SerializeField] private long playerMoney;
    private void Awake()
    {
        LoadMoneyData();
    }
    public void LoadMoneyData()
    {

        string jsonData = File.ReadAllText(Application.dataPath + "/PlayerFinance.json");
        MoneyData data = JsonUtility.FromJson<MoneyData>(jsonData);
        playerMoney = data.value;

    }
    public void SaveMoneyData()
    {
        MoneyData playerData = new MoneyData();
        playerData.value = playerMoney;

        string jsonData = JsonUtility.ToJson(playerData);

        File.WriteAllText(Application.dataPath + "/PlayerFinance.json", jsonData);
    }
    private class MoneyData
    {
        public long value;
    }
}

