using UnityEngine;

public class ControlLights : Control
{
    private bool isEnable;

    private void Start() => ChangeButtonColor(Color.grey);

    protected override void ControlObjects()
    {
        if (isEnable == true)
        {
            isEnable = true;
            ChangeButtonColor(Color.grey);
        }
        else
        {
            
            isEnable = false;
            ChangeButtonColor(Color.yellow);
        }

        isEnable = !isEnable;
        controlObject.SetActive(isEnable);
        onEnableObject?.Invoke(isEnable, 0.1f);
    }

    public void DisableControlLights()
    {
        controlObject.SetActive(false);
        ChangeButtonColor(Color.grey);

        Destroy(this);
    }
}
