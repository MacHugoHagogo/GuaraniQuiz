using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class GoogleMobileAdsDemoScript : MonoBehaviour
{
    private RewardBasedVideoAd rewardBasedVideo;
  //  public Text  valor;
  //  public Text descicao;
    public Text macas;
    public int vidas;
  

    public void Start()
    {
        vidas = PlayerPrefs.GetInt("vidas");
        macas.text = vidas.ToString();
        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

        this.RequestRewardBasedVideo();
    }

    private void RequestRewardBasedVideo()
    {

#if UNITY_ANDROID
        //string adUnitId = "ca-app-pub-6697782785420626~5013223268";
        string adUnitId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-6697782785420626~5499065158";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardBasedVideoFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
      // valor.text = amount.ToString();
      //  descicao.text = type.ToString();
       // macas.text = vidas.ToString();
      //  PlayerPrefs.SetInt("vidas", vidas = vidas + 1);
        MonoBehaviour.print(
            "HandleRewardBasedVideoRewarded event received for "
            + amount.ToString() + " " + type + "Vidas" + macas.ToString());
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }

    public void GameOver()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            print("Passou pelo GameOver - 1");
            rewardBasedVideo.Show();
            vidas++;
            PlayerPrefs.SetInt("vidas", vidas);
            macas.text = vidas.ToString();
            this.RequestRewardBasedVideo();
            print("vidas = " + vidas);
            macas.text = vidas.ToString();



        }
    }
    public void VaiParaTemas()
    {

        SceneManager.LoadScene("Tema");


    }

}

