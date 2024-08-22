using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ControlSound : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Toggle toggle;
    [SerializeField] private Slider slider;

    private const string mixerCheckboxName = "CheckboxVolume", mixerSliderName = "SliderVolume";
    private const string soundKey = "MusicOn";

    private void Start()
    {
        toggle.GetComponentInChildren<Toggle>().isOn = PlayerPrefs.GetInt(soundKey) == 0;
        slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat(mixerSliderName);
    }

    public void EnableMusic(bool isEnable)
    {
        if (isEnable == true)
            mixer.SetFloat(mixerCheckboxName, 0);
        if (isEnable == false)
            mixer.SetFloat(mixerCheckboxName, -80);

        PlayerPrefs.SetInt(soundKey, isEnable ? 0 : 1);
    }

    public void ChangeVolume(float volume)
    {
        mixer.SetFloat(mixerSliderName, Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat(mixerSliderName, volume);
    }
}
