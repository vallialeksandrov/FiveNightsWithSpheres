using UnityEngine;

public class LoseUI : MonoBehaviour
{
    [SerializeField] private GameObject loseCanvas;

    private void Lose() => loseCanvas.SetActive(true);

    private void OnEnable() => Screamer.onLost += Lose;

    private void OnDisable() => Screamer.onLost -= Lose;
}
