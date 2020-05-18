using UnityEngine;

public class MainMenuAdsController : MonoBehaviour
{
    private int _timesUserMainMenu;
    // Start is called before the first frame update
    void Start()
    {
        _timesUserMainMenu = PlayerPrefs.GetInt("timesInMainMenu");
        _timesUserMainMenu = _timesUserMainMenu +1;
        PlayerPrefs.SetInt("timesInMainMenu", _timesUserMainMenu);

        if (_timesUserMainMenu >= 3)
        {
            GetComponentInChildren<InterstitialAdScript>().CreateInterstitialAd();
            PlayerPrefs.SetInt("timesInMainMenu", 0);
        }
    }
}
