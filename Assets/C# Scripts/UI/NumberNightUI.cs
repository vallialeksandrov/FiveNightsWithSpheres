using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NumberNightUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nightText;
    [SerializeField] private Button continueButton;

    private const string keyName = "Nights";

    private void Start()
    {
        if (PlayerPrefs.HasKey(keyName) && PlayerPrefs.GetInt(keyName) <= 5)
        {
            nightText.text = "���������� (" + PlayerPrefs.GetInt(keyName) + " ����)";
            continueButton.interactable = true;
        }
        else if (PlayerPrefs.GetInt(keyName) > 5)
        {
            nightText.text = "�� ������ ����!";
            continueButton.interactable = false;
        }
        else
        {
            nightText.text = null;
            continueButton.interactable = false;
        }
    }
}
