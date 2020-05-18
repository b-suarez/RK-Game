using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardAdsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<BannerScript>().CreateBottomBanner();
    }
}
