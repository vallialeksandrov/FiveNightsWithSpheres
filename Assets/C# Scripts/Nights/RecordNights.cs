using UnityEngine;
using YG;

public class RecordNights : MonoBehaviour
{
    private int allNigths;

    private const string keyAllNights = "AllNights";
    private const string leaderboardName = "LeaderboardNights";

    private void Start() => allNigths = PlayerPrefs.GetInt(keyAllNights);
    private void Record()
    {
        allNigths++;
        PlayerPrefs.SetInt(keyAllNights, allNigths);

        YandexGame.NewLeaderboardScores(leaderboardName, allNigths);
    }

    private void OnEnable() => Nights.onEndedNight += Record;

    private void OnDisable() => Nights.onEndedNight -= Record;      
}
