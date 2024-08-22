using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CheckerPosition))]
public class EnemyController : MonoBehaviour
{
    public static UnityAction onMoved;

    private CheckerPosition checkPosition;

    [Header("Стартовая позиция")]
    [SerializeField] private Transform newPosition;

    [Header("Вероятность")]
    [SerializeField] private int[] probability;
    private int currentProbability;

    [Header("Минимальное и максимальное время начала")]
    [SerializeField] private int[] minStartTime;
    [SerializeField] private int[] maxStartTime;

    [Header("Минимальное и максимальное время между шагами")]
    [SerializeField] private int[] minStepTime;
    [SerializeField] private int[] maxStepTime;

    private int numberNight;
    private const string keyName = "Nights";

    private void Start()
    {
        CheckNight();

        checkPosition = GetComponent<CheckerPosition>();

        currentProbability = probability[numberNight];       

        Invoke(nameof(ChangePosition), Random.Range(minStartTime[numberNight], maxStartTime[numberNight]));
    }

    public void ChangePosition()
    {
        NextPositions nextPosition = newPosition.GetComponent<NextPositions>();
        newPosition = nextPosition.TakeNextPosition(currentProbability);

        if (newPosition.GetComponent<NextPositions>().IsTaken == false)
            newPosition.GetComponent<NextPositions>().IsTaken = true;
        else
            newPosition = nextPosition.TakeBackPosition();

        onMoved?.Invoke();
        transform.SetPositionAndRotation(newPosition.position, newPosition.rotation);

        checkPosition.CheckEndPosition();

        Invoke(nameof(ChangePosition), Random.Range(minStepTime[numberNight], maxStepTime[numberNight]));
    }

    public void ChangeProbability(int newProbability)
    {
        currentProbability = newProbability;

        int randTime = Random.Range(10, 30);
        Invoke(nameof(RestoreProbability), randTime);

        Invoke(nameof(ChangePosition), Random.Range(5, 15));
    }

    private void RestoreProbability() => currentProbability = probability[numberNight];

    private void CheckNight()
    {
        if (PlayerPrefs.HasKey(keyName))
            numberNight = PlayerPrefs.GetInt(keyName) - 1;
        else
            numberNight = 0;
    }
}
