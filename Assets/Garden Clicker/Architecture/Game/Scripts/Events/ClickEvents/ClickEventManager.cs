using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClickEventManager : MonoBehaviour
{
    public static ClickEventManager Instance;

    [HideInInspector] public UnityEvent OnButtonClick;
    

    private static string clickButtonName = "MainClickButton";
    private Button mainButtonClick;
    private void Awake()
    {
        if (mainButtonClick == null) mainButtonClick = GameObject.Find(clickButtonName).GetComponent<Button>();
        if (Instance == null) Instance = this;

        mainButtonClick.onClick.AddListener(OnButtonClick.Invoke);
    }
}
