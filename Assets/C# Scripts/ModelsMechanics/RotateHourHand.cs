using UnityEngine;

public class RotateHourHand : MonoBehaviour
{
    [SerializeField] private float forceRotation;

    private void RotateHand() => transform.Rotate(Vector3.down, forceRotation);

    private void OnEnable() => Times.onUpdatedTime += RotateHand;

    private void OnDisable() => Times.onUpdatedTime -= RotateHand;
}
