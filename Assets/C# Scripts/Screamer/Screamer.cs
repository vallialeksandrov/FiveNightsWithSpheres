using UnityEngine;
using UnityEngine.Events;

public class Screamer : MonoBehaviour
{
    public static UnityAction onLost;

    [Header("Камеры")]
    [SerializeField] private Cameras cameras;

    [Header("Дополнительный свет")]
    [SerializeField] private GameObject screamerLight;

    [Header("Базовый канвас")]
    [SerializeField] private GameObject baseCanvas;

    [Header("Планшет")]
    [SerializeField] private GameObject tablet;

    public void Start()
    {
        gameObject.SetActive(true);
        screamerLight.SetActive(true);

        baseCanvas.SetActive(false);
        tablet.SetActive(false);

        cameras.DisableCamera();
    }

    public void Scream()
    {
        gameObject.SetActive(true);
        screamerLight.SetActive(true);

        baseCanvas.SetActive(false);
        tablet.SetActive(false);
        
        cameras.DisableCamera(); 
    }
  
    //срабатывает после проигрыша анимации
    private void DisableScream()
    {     
        onLost?.Invoke();
        this.enabled = false;     
    }
}
