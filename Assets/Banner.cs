using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class Banner : MonoBehaviour
{
    private BannerView bannerView;

    string adUnitId;

    public string AndroidBannerAddId;
    public string IosBannderAddId;

    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        DontDestroyOnLoad(this.gameObject);
        Debug.Log("StartGame");
        MobileAds.Initialize(initStatus => { });


        this.RequestBanner();
    }

    
    private void RequestBanner()
    {
#if UNITY_ANDROID
        adUnitId = AndroidBannerAddId;
#elif UNITY_IPHONE
             adUnitId = IosBannderAddId;
#else
             adUnitId = AndroidBannerAddId;
#endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        if (adUnitId != "")
            this.bannerView.LoadAd(request);

    }
}