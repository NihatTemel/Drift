using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InterstellerAdd : MonoBehaviour
{

    private InterstitialAd interstitial;
    string adUnitId;

    public string AndroidInterstitialAddId;
    public string IosInterstitialAddId;

    void Start()
    {
        MobileAds.Initialize(initstatus => { });
        RequestInterstitial();

        

        if (interstitial.IsLoaded())
        {

             if(PlayerPrefs.GetInt("add")%2==1)
            if (adUnitId != "")
                interstitial.Show();
        }
        PlayerPrefs.SetInt("add", PlayerPrefs.GetInt("add") + 1);
        
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        adUnitId = AndroidInterstitialAddId;
#elif UNITY_IPHONE
         adUnitId = IosInterstitialAddId;
#else
         adUnitId = AndroidInterstitialAddId;
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
}
