using UnityEngine;
using TMPro;

public class WelcomeText : MonoBehaviour
{
    [SerializeField] private GameObject imageObject;
    [SerializeField] private TMP_Text welcomeText, nightText;

    private const string keyName = "Nights";

    private void Start()
    {
        imageObject.SetActive(true);

        if (PlayerPrefs.HasKey(keyName))
        {
            welcomeText.text = "00:00\n" + PlayerPrefs.GetInt("Nights") + " ����";
            nightText.text = PlayerPrefs.GetInt(keyName) + " ����";
        }
            
        else
        {
            welcomeText.text = "00:00\n" + "1 ����";
            nightText.text = "1 ����";
        }          
    }
}
