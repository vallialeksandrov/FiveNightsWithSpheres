using UnityEngine;
using UnityEngine.Events;

public class Nights : MonoBehaviour
{
    public static UnityAction onEndedNight;

    [SerializeField] private Scenes scenes;

    [SerializeField] private int numberNight;

    private const string keyName = "Nights";

    private void Start()
    {
        if (PlayerPrefs.HasKey(keyName))
            numberNight = PlayerPrefs.GetInt(keyName);
        else
            numberNight = 1;
    }

    public void CheckNight()
    {
        numberNight++;
        PlayerPrefs.SetInt(keyName, numberNight);

        onEndedNight?.Invoke();
        
        scenes.ChangeScenes(4);
    }

    private void OnEnable() => Times.onWon += CheckNight;

    private void OnDisable() => Times.onWon -= CheckNight;
}
