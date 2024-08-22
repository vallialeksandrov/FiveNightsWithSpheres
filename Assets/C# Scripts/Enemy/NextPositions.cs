using UnityEngine;

public class NextPositions : MonoBehaviour
{   
    [SerializeField] private Transform[] nextPositions, backPositions;

    public bool IsTaken;

    public Transform TakeNextPosition(int probability)
    {
        int rand = Random.Range(0, 100);

        if (rand <= probability)
        {
            int randNextStep = Random.Range(0, nextPositions.Length);
            IsTaken = false;
            return nextPositions[randNextStep];             
        }
        else
        {
            int randBackStep = Random.Range(0, backPositions.Length);
            IsTaken = false;
            return backPositions[randBackStep];
        }      
    }

    public Transform TakeBackPosition()
    {
        int randBackStep = Random.Range(0, backPositions.Length);
        IsTaken = false;
        return backPositions[randBackStep];
    }
}
