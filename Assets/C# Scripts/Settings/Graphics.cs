using UnityEngine;

public class Graphics : MonoBehaviour
{
    private const string qualityKey = "CurrentQuality";

    private void Start()
    {
        if (PlayerPrefs.HasKey(qualityKey))
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt(qualityKey), true);
        else
            QualitySettings.SetQualityLevel(5, true);
    }

    public void ChangeQuality(int numberLevel)
    {
        QualitySettings.SetQualityLevel(numberLevel, true);
        PlayerPrefs.SetInt(qualityKey, numberLevel);
    }
}
