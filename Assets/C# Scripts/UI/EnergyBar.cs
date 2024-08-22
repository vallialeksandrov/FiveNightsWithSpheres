using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private Image bar;
    [SerializeField] private Color[] colors;

    private int spentLevel = 0;
 
    private void Start()
    {
        bar = GetComponent<Image>();
        bar.fillAmount = 0.2f;
    }

    private void FillBar(bool isEnable, float energy)
    {
        if (isEnable == true)
        {
            bar.fillAmount += 0.16f;
            spentLevel++;           
        }
            
        else
        {
            bar.fillAmount -= 0.16f;
            spentLevel--;
        }

        bar.color = colors[spentLevel];
    }

    private void OnEnable()
    {
        Control.onEnableObject += FillBar;
        CameraPanel.onEnabledCamera += FillBar;
    }

    private void OnDisable()
    {
        Control.onEnableObject -= FillBar;
        CameraPanel.onEnabledCamera -= FillBar;
    }
}
