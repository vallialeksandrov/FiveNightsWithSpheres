using UnityEngine;

public class RotateBladesFan : MonoBehaviour
{
    [SerializeField] private int forceRotate;

    private void Update() => transform.Rotate(0, forceRotate, 0);
}
