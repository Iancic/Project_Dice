using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAds : MonoBehaviour, IUnityAdsInitializationListener
{
    private string androidGameID = "5410825";
    private string iosGameID = "5410824";

    public bool isTestingMode = true;

    public string gameId;

    void Awake()
    {
        AdsInitialization();
    }

    void AdsInitialization()
    {

#if UNITY_IOS
    gameId = iosGameID;
#elif UNITY_ANDROID
    gameId = androidGameID;
#endif

        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, isTestingMode, this);
        }

    }

    public void OnInitializationComplete()
    {
        print("Ad Initialized");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        print("Ad Failed");
    }

}
