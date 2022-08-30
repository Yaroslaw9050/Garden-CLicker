using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIDeskController : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private TMP_Text progressTitleText;

    private void Awake()
    {
        progressBar = gameObject.GetComponentInChildren<Slider>();
        progressTitleText = gameObject.GetComponentInChildren<TMP_Text>();
    }

    public void SetDeskParameter(float maxBarValue, float barValue, string titleText)
    {
        progressBar.maxValue = maxBarValue;
        progressBar.value = barValue;

        progressTitleText.text = titleText;
    }
}
