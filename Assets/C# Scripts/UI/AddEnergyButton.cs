using UnityEngine;

public class AddEnergyButton : MonoBehaviour
{
    [SerializeField] private GameObject energyButton;
    private int limitedEnergy = 15;

    private void CheckEnergy(float energy)
    {
        if (energy < limitedEnergy)
        {
            energyButton.SetActive(true);
            this.enabled = false;
        }            
    }

    private void OnEnable() => Energy.onUpdatedEnergy += CheckEnergy;

    private void OnDisable() => Energy.onUpdatedEnergy -= CheckEnergy;
}
