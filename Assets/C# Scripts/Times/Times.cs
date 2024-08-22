using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Times : MonoBehaviour
{
    public static UnityAction onUpdatedTime, onWon;

    // Время ночи, время часа
    [SerializeField] private int nightTime = 270, hourTime = 45;

    private void Start() => StartCoroutine(Timer());

    private IEnumerator Timer()
    {
        while (nightTime > 0)
        {
            yield return new WaitForSeconds(1);

            nightTime--;
            UpdateHourTime();
        }

        onWon?.Invoke();
    }

    private void UpdateHourTime()
    {
        hourTime--;

        if (hourTime == 0)
        {
            onUpdatedTime?.Invoke();
            hourTime = 45;
        }
    }
}
