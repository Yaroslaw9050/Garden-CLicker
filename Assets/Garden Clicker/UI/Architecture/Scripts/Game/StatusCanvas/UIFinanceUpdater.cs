using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIFinanceUpdater : MonoBehaviour
{

    [SerializeField] private Color defaultTextColor;
    [SerializeField] private Color plassTextColor;
    [SerializeField] private Color minusTextColor;

    private const string FINANCE_TEXT_NAME = "FinanceTitleText";
    private TMP_Text financeText;


    private void Awake()
    {
        financeText = GameObject.Find(FINANCE_TEXT_NAME).GetComponent<TMP_Text>();
    }
    public void UpdateUIValue(long financeValue)
    {
        financeText.text = $"{financeValue}$";
        SetDefaultColor();
    }
    public void UpdateUIValue(long financeValue, bool isPositiveAdd)
    {
        if(isPositiveAdd)
        {
            financeText.text = $"{financeValue}$";
            financeText.DOColor(plassTextColor, 0.5f).OnComplete(SetDefaultColor);
            return;
        }

        financeText.text = $"{financeValue}$";
        financeText.DOColor(minusTextColor, 0.5f).OnComplete(SetDefaultColor);

    }
    private void SetDefaultColor()
    {
        financeText.DOColor(defaultTextColor, 0.2f);
    }
}
