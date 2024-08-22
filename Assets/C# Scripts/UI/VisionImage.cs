using UnityEngine;

public class VisionImage : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    private int probability = 3;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();  
    }

    public void EnableVision()
    {
        int rand = Random.Range(0, 100);

        if (rand <= probability)
        {
            int randVision = Random.Range(1, 5);
            animator.SetInteger("NumberVision", randVision);
            audioSource.Play();
        }     
    }

    private void DisableVision()
    {
        animator.SetInteger("NumberVision", 0);
    }
}
