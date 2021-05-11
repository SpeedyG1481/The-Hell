using System;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.UI;

namespace Ads
{
    public class CheckPointAd : MonoBehaviour
    {
        private InterstitialAd _interstitial;
        private Button _button;
        private string androidAdId = "ca-app-pub-8847668020520840/6846194270";
        private string iOSAdId = "ca-app-pub-8847668020520840/1014997689";

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnPointerDown);
        }

        private void InterstitialAdLoad()
        {
            var adId = iOSAdId;
            if (Application.platform == RuntimePlatform.Android)
            {
                adId = androidAdId;
            }

            adId = "ca-app-pub-3940256099942544/1033173712";

            _interstitial = new InterstitialAd(adId);
            var adRequest = new AdRequest.Builder().Build();
            _interstitial.OnAdLoaded += AdLoaded;
            _interstitial.LoadAd(adRequest);
        }

        private void AdLoaded(object sender, EventArgs e)
        {
            _interstitial.Show();
        }

        private void OnPointerDown()
        {
            MobileAds.Initialize(x => { InterstitialAdLoad(); });
        }
    }
}