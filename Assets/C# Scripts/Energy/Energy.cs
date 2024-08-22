using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Energy : MonoBehaviour
{
    public static UnityAction<float> onUpdatedEnergy;
    public static UnityAction onEndedEnergy;
     
    [SerializeField] private float energy;
    [SerializeField] private float[] _expense;

    private const string keyName = "Nights";
    private int numberNight;

    private void Start()
    {
        if (PlayerPrefs.HasKey(keyName))
            numberNight = PlayerPrefs.GetInt(keyName) - 1;
        else
            numberNight = 0;

        energy = 100;
        StartCoroutine(UseEnergy());
    }

    private IEnumerator UseEnergy()
    {
        while (energy > 0)
        {
            yield return new WaitForSeconds(1f);
            energy -= _expense[numberNight];

            onUpdatedEnergy?.Invoke(energy);
        }

        onEndedEnergy?.Invoke();
    }

    private void IncreaseExpenseEnergy(bool isEnable, float expense)
    {
        if (isEnable == true)
            _expense[numberNight] += expense;
        else
            _expense[numberNight] -= expense;
    }

    public void AddEnergy() => energy += 15;

    private void OnEnable()
    {
        Control.onEnableObject += IncreaseExpenseEnergy;
        CameraPanel.onEnabledCamera += IncreaseExpenseEnergy;
    }

    private void OnDisable()
    {
        Control.onEnableObject -= IncreaseExpenseEnergy;
        CameraPanel.onEnabledCamera -= IncreaseExpenseEnergy;
    }
}
