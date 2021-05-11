using System;
using GoogleMobileAds.Api;
using UnityEngine;

namespace Ads
{
    public class TenDeadAd
    {
        private InterstitialAd _interstitial;
        private string androidAdId = "ca-app-pub-8847668020520840/2846954106";
        private string iOSAdId = "ca-app-pub-8847668020520840/5976159253";


        public void ShowAd()
        {
            MobileAds.Initialize(x => { InterstitialAdLoad(); });
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
    }
}