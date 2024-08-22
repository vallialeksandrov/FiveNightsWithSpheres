using UnityEngine;
using UnityEngine.Events;

public class DoorButton : MonoBehaviour
{
    public static UnityAction onClosed;

    private void OnMouseDown() => onClosed?.Invoke();
}
