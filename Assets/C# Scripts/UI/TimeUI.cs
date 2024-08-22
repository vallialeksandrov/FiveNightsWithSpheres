using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    private int hourTime;

    private void Start()
    {
        hourTime = 0;
        timeText.text = hourTime.ToString("0:00");
    }

    private void UpdateTimeText()
    {
        hourTime += 100;
        timeText.text = hourTime.ToString("0:00 ");
    }

    private void OnEnable() => Times.onUpdatedTime += UpdateTimeText;

    private void OnDisable() => Times.onUpdatedTime -= UpdateTimeText;
}
