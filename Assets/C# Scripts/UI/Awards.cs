using UnityEngine;

public class Awards : MonoBehaviour
{
    [SerializeField] private GameObject[] awardsImages;

    private const string keyName = "Nights";

    private void Start()
    {
        for (int i = 0; i < awardsImages.Length; i++)
            awardsImages[i].SetActive(false);

        EnableAwards();
    }

    private void EnableAwards()
    {
        int competedNight = PlayerPrefs.GetInt(keyName) - 1;

        for (int i = 0; i < competedNight; i++)
            awardsImages[i].SetActive(true);
    }
}
