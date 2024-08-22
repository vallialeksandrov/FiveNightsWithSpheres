using UnityEngine;

public class DisableObjects : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Управление")]
    [SerializeField] private ControlDoors[] controlDoors;
    [SerializeField] private ControlLights[] controlLights;

    [Header("Свет")]
    [SerializeField] private GameObject baseLight;
    [SerializeField] private GameObject spareLight;

    [Header("Объекты")]
    [SerializeField] private RotateBladesFan rotateBladesFan;
    [SerializeField] private AudioSource fanAudioSource;
    [SerializeField] private GameObject appleMac;

    [Header("UI")]
    [SerializeField] private GameObject canvas;

    private void Start() => audioSource = GetComponent<AudioSource>();

    private void Disable()
    {
        for (int i = 0; i < controlDoors.Length; i++)
            controlDoors[i].DisableControlDoors();

        for (int i = 0; i < controlLights.Length; i++)
            controlLights[i].DisableControlLights();

        Destroy(rotateBladesFan);
        fanAudioSource.Stop();

        appleMac.SetActive(false);
        canvas.SetActive(false);

        baseLight.SetActive(false);
        spareLight.SetActive(true);

        audioSource.Play();
    }

    private void OnEnable() => Energy.onEndedEnergy += Disable;

    private void OnDisable() => Energy.onEndedEnergy -= Disable;
}
