using UnityEngine;

public class StartCharacters : MonoBehaviour
{
    [SerializeField] private GameObject[] startEnemies;

    private void Start()
    {
        int randEnemy = Random.Range(0, startEnemies.Length);
        startEnemies[randEnemy].SetActive(true);
    }
}
