using System.Collections;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    private ShaderEffect_CorruptedVram seCV;
    private ShaderEffect_CRT seCRT;
    private ShaderEffect_Unsync seU;

    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        seCV = GetComponent<ShaderEffect_CorruptedVram>();
        seCRT = GetComponent<ShaderEffect_CRT>();
        seU = GetComponent<ShaderEffect_Unsync>();
    }

    public void CreateInterference()
    {
        EnableEffects(true);
        audioSource.Play();

        StartCoroutine(DisableEffects());
    }

    private IEnumerator DisableEffects()
    {
        yield return new WaitForSeconds(1);
        EnableEffects(false);
    }

    private void EnableEffects(bool isEnable)
    {
        seCV.enabled = isEnable;
        seCRT.enabled = isEnable;
        seU.enabled = isEnable;
    }

    private void OnEnable() => EnemyController.onMoved += CreateInterference;

    private void OnDisable() => EnemyController.onMoved -= CreateInterference;
}
