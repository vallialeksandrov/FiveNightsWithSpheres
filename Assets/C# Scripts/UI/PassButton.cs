using UnityEngine;

public class PassButton : MonoBehaviour
{
    private const string keyName = "PassNight";

    [SerializeField] private GameObject passNightButton;

    private void Start()
    {
        if (PlayerPrefs.GetInt(keyName) >= 1)
            passNightButton.SetActive(false);
        else
            passNightButton.SetActive(true);
    }
}
