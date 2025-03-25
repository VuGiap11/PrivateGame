using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Private
{
    public class AdsManager : MonoBehaviour
    {
        public static AdsManager instance;
        private BannerView bannerView;
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
        private void Start()
        {
            MobileAds.Initialize((InitializationStatus initStatus) =>
            {
                // This callback is called once the MobileAds SDK is initialized.
            });
            DontDestroyOnLoad(this);
            RequestBanner();
        }

        public void RequestBanner(AdPosition position = AdPosition.Bottom)
        {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
#endif
            //AdSize ad = new AdSize(300, 40); lưu kích thước mới
            // Create a 320x50 banner at the top of the screen.
            bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
            // Create an empty ad request.
            AdRequest request = new AdRequest();
            // Load the banner with the request.
            bannerView.LoadAd(request);

        }

        public void ShowBanner()
        {
            bannerView.Show();
        }
        public void HideBanner()
        {
            bannerView.Hide();
        }
        public void DestroyBanner()
        {
            bannerView.Destroy();
        }

    }
}