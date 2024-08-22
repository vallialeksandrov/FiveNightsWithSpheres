using UnityEngine;

public class Cameras : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;

    private void Start() => EnableCamera(0);

    public void EnableCamera(int number)
    {
        DisableCamera();
        cameras[number].enabled = true;
    }

    public void DisableCamera()
    {
        foreach (Camera cam in cameras)
            cam.enabled = false;
    }
}

