using System.Collections;
using UnityEngine;

public class CheckerPosition : MonoBehaviour
{
    private EnemyController enemyController;

    [Header("Скрипт скримера")]
    [SerializeField] private Screamer screamer;

    [Header("Двери")]
    [SerializeField] private ControlDoors leftDoor;
    [SerializeField] private ControlDoors rightDoor;

    [Header("Свет")]
    [SerializeField] private GameObject leftLights;
    [SerializeField] private GameObject rightLights;

    [Header("Крайние позиции")]
    [SerializeField] private Transform leftPosition;
    [SerializeField] private Transform rightPosition;

    [Header("Кол-во нажатий")]
    [SerializeField] private int countPress = 0;
    private int tryOpenDoor = 4;

    private bool isDecreaseTime;

    private void Start() => enemyController = GetComponent<EnemyController>();

    public void CheckEndPosition()
    {
        if (transform.position == leftPosition.position && leftDoor.IsClose == false || transform.position == rightPosition.position && rightDoor.IsClose == false)
        {
            isDecreaseTime = true;
            StartCoroutine(ScreamerTimer());

            rightLights.SetActive(false);
            leftLights.SetActive(false);

            countPress += 1;

            if (countPress >= tryOpenDoor)
                screamer.Scream();
        }

        else if (transform.position == leftPosition.position && leftDoor.IsClose == true || transform.position == rightPosition.position && rightDoor.IsClose == true)
        {
            StopScreamerAndBreakTimer();
            enemyController.ChangeProbability(0);
        }

        else
        {
            StopScreamerAndBreakTimer();
            countPress = 0;
        }
    }

    private IEnumerator ScreamerTimer()
    {
        int screamTimer = Random.Range(5, 15);

        while (isDecreaseTime == true)
        {
            yield return new WaitForSeconds(1f);

            if (screamTimer > 0)
                screamTimer--;
            else
                screamer.Scream();
        }
    }

    private void StopScreamerAndBreakTimer()
    {
        isDecreaseTime = false;

        StopCoroutine(ScreamerTimer());
    }

    private void OnEnable() => DoorButton.onClosed += CheckEndPosition;
      
    private void OnDisable() => DoorButton.onClosed -= CheckEndPosition;   
}
