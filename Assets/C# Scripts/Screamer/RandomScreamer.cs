using UnityEngine;

public class RandomScreamer : MonoBehaviour
{
    [SerializeField] private Screamer[] screamers;

    private void StartRandomScream()
    {
        int randTime = Random.Range(5, 10);
        Invoke(nameof(RandomScream), randTime);
    }

    private void RandomScream()
    {       
        int randScream = Random.Range(0, screamers.Length);    
        screamers[randScream].Scream();
    }

    private void OnEnable() => Energy.onEndedEnergy += StartRandomScream;

    private void OnDisable() => Energy.onEndedEnergy -= StartRandomScream;
}
