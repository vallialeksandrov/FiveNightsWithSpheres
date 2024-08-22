using System.Collections;
using UnityEngine;

public class TelephoneCall : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] calls;

    [SerializeField] private GameObject buttonCall;

    private void Start() => Invoke(nameof(Call), 5f);

    private void Call()
    {
        int numberCall;

        if (PlayerPrefs.HasKey("Nights"))
            numberCall = PlayerPrefs.GetInt("Nights") - 1;
        else
            numberCall = 0;

        audioSource.clip = calls[numberCall];
        audioSource.Play();

        StartCoroutine(DisableButton());
        buttonCall.SetActive(true);
    }

    private IEnumerator DisableButton()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        buttonCall.SetActive(false);
    }
}
