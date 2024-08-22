using UnityEngine;

public class MuteCall : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void Mute()
    {
        audioSource.enabled = false;
        gameObject.SetActive(false);
    }
}
