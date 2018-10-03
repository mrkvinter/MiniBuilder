using UnityEngine;
using UnityEngine.UI;

public class CountCoinsCollectedController : MonoBehaviour
{
    public OnClickListener PanelDisableEvent;

    public Text TextCompleteInformation;

    private void Start()
    {
        if (HouseChangerManager.Instance.CurrentLevel == 0) PanelDisableEvent.OnClick.Invoke();
        TextCompleteInformation.text = $"YOU COLLECTED {HouseChangerManager.Instance.CoinsCount * 100}$ OF 300$";
    }
}