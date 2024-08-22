using UnityEngine;
using TMPro;

public class AllNightsText : MonoBehaviour
{
    private TMP_Text allNightText;
    private const string keyAllNights = "AllNights";

    private void Start()
    {
        allNightText = GetComponent<TMP_Text>();
        allNightText.text = "Прожито ночей: " + PlayerPrefs.GetInt(keyAllNights).ToString();
    }
}
