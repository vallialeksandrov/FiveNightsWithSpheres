using UnityEngine;
using YG;

public class YG_Ads : MonoBehaviour
{
    [SerializeField] private Energy energy;
    [SerializeField] private Nights nights;
    [SerializeField] private Scenes scenes;

    private const string key = "PassNight";

    private void OnEnable() => YandexGame.RewardVideoEvent += CheckAdsID;

    private void OnDisable() => YandexGame.RewardVideoEvent -= CheckAdsID;

    private void CheckAdsID(int id) 
    {
        if (id == 0)
        {
            energy.AddEnergy();
        }            
        if (id == 1)
        {
            PlayerPrefs.SetInt(key, 1);
            nights.CheckNight();
        }            
    }

    public void WatchAds(int id) => YandexGame.RewVideoShow(id); 
}
