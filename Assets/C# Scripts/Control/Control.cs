using UnityEngine;
using UnityEngine.Events;

public abstract class Control : MonoBehaviour
{
    public static UnityAction<bool, float> onEnableObject;

    [SerializeField] protected GameObject controlObject;
    [SerializeField] protected Material controlMaterial;

    private void OnMouseDown() => ControlObjects();

    protected abstract void ControlObjects();

    protected void ChangeButtonColor(Color color) => controlMaterial.SetColor("_EmissionColor", color);
}
