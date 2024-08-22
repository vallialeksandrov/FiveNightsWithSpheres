using UnityEngine;
using UnityEngine.Events;

public class Screamer : MonoBehaviour
{
    public static UnityAction onLost;

    [Header("������")]
    [SerializeField] private Cameras cameras;

    [Header("�������������� ����")]
    [SerializeField] private GameObject screamerLight;

    [Header("������� ������")]
    [SerializeField] private GameObject baseCanvas;

    [Header("�������")]
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
  
    //����������� ����� ��������� ��������
    private void DisableScream()
    {     
        onLost?.Invoke();
        this.enabled = false;     
    }
}
