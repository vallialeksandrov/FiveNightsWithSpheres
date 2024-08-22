using UnityEngine;

public class StartEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] firstEnemies, secondEnemies, thirdEnemies;

    private void Start()
    {
        int firstEnemy = Random.Range(0, firstEnemies.Length);
        firstEnemies[firstEnemy].SetActive(true);

        int secondEnemy = Random.Range(0, secondEnemies.Length);
        secondEnemies[secondEnemy].SetActive(true);

        int thirdEnemy = Random.Range(0, thirdEnemies.Length);
        thirdEnemies[thirdEnemy].SetActive(true);
    }
}
