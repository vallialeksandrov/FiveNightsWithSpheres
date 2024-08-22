using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    private float rotateZone = Screen.width / 4;

    private void Update() => Rotate();

    private void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x < rotateZone && transform.rotation.eulerAngles.y > 150)
                transform.Rotate(0, -sensitivity * Time.deltaTime, 0);
            if (Input.mousePosition.x > Screen.width - rotateZone && transform.rotation.eulerAngles.y < 210)
                transform.Rotate(0, sensitivity * Time.deltaTime, 0);
        }       
    }
}
