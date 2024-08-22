using UnityEngine;
using TMPro;

public class WinUI : MonoBehaviour
{
    private const string keyName = "Nights";

    [SerializeField] private TMP_Text winText;
    [SerializeField] private GameObject continueButton;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        if (PlayerPrefs.GetInt(keyName) > 5)
        {
            animator.enabled = true;
            continueButton.SetActive(false);
        }        
    }   
}
