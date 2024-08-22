using UnityEngine;
using TMPro;

public class EnergyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text energyText;

    private void Start() => UpdateText(100);

    private void OnEnable() => Energy.onUpdatedEnergy += UpdateText;

    private void OnDisable() => Energy.onUpdatedEnergy -= UpdateText;

    private void UpdateText(float energy) => energyText.text = "Батарея: " + energy.ToString("0") + "%";
}
