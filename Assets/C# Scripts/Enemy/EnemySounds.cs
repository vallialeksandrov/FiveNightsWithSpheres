using System.Collections;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    [SerializeField] private AudioSource enemyAS;
    [SerializeField] private AudioClip[] clips;

    private void Start() => StartCoroutine(PlaySound());

    private IEnumerator PlaySound()
    {
        while (true)
        {
            int randTime = Random.Range(15, 150);
            yield return new WaitForSeconds(randTime);

            enemyAS.clip = clips[Random.Range(0, clips.Length)];
            enemyAS.Play();
        }    
    }
}
