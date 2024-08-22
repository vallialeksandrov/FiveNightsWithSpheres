using UnityEngine;

public class ClearResult : MonoBehaviour
{
    private const string keyNightName = "Nights", keyPassNigth = "PassNight";

    public void Clear()
    {
        PlayerPrefs.DeleteKey(keyNightName);
        PlayerPrefs.DeleteKey(keyPassNigth);
    }
}

