using UnityEngine;
using UnityEngine.Events;

public class CameraPanel : MonoBehaviour
{
    public static UnityAction<bool, float> onEnabledCamera;

    [SerializeField] private Cameras cameras;
    [SerializeField] private GameObject panel;

    [SerializeField] private Animator cameraPanelAnimator;
    private AudioSource audioSource;

    private bool isOpen;

    private void Start() => audioSource = GetComponent<AudioSource>();

    public void OpenCloseTablet()
    {
        cameraPanelAnimator.SetBool("isOpen", !isOpen);
        Invoke(nameof(OpenClosePanel), 0.2f);

        audioSource.Play();
    }

    private void OpenClosePanel()
    {
        if (isOpen == false)
            cameras.EnableCamera(1);
        else
            cameras.EnableCamera(0);

        isOpen = !isOpen;
        panel.SetActive(isOpen);

        onEnabledCamera?.Invoke(isOpen, 0.1f);
    }

    private void CheckEnergy(float energy)
    {
        if (energy < 15)
        {
            panel.SetActive(false);
            gameObject.SetActive(false);
            cameras.EnableCamera(0);
            cameraPanelAnimator.SetBool("isOpen", false);
        }         
    }

    private void OnEnable() => Energy.onUpdatedEnergy += CheckEnergy;

    private void OnDisable() => Energy.onUpdatedEnergy -= CheckEnergy;
}
