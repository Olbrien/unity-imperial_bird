using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class PlayerControllerCollector : MonoBehaviour
{
    [Header("Main Menu")]

    public bool levelOneComplete;
    public bool levelTwoComplete;
    public bool levelThreeComplete;

    public bool healthFour;
    public bool healthFive;
    public bool healthSix;

    public int adsWatched;

    [Header("Game Stuff")]

    public int levelOneDeaths;
    public int levelTwoDeaths;
    public int levelThreeDeaths;

    public int levelOneCompletedDeaths;
    public int levelTwoCompletedDeaths;
    public int levelThreeCompletedDeaths;

    public float levelOneCompletePercentage;
    public float levelTwoCompletePercentage;
    public float levelThreeCompletePercentage;

    [Header("Sound Stuff")]

    public float musicVolume;
    public float soundVolume;

    

    PlayerController playerController;

    public Slider musicSlider;
    public Slider soundSlider;


    string gameID = "3406291";
    bool testMode = true;
    string rewardedVideoPlacementID = "rewardedVideo";
    string regularPlacementID = "video";

    MenuController menuController;


    private void Awake()
    {
        Advertisement.Initialize(gameID);
    }

    void Start()
    {
        menuController = FindObjectOfType<MenuController>();

        playerController = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>();
        
        UpdateEverything();

        //Debug.Log(Application.persistentDataPath);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SaveGameToMain();
           //Debug.Log("Game Saved");
        }
    }

    void UpdateEverything()
    {
        levelOneDeaths = playerController.levelOneDeaths;
        levelTwoDeaths = playerController.levelTwoDeaths;
        levelThreeDeaths = playerController.levelThreeDeaths;

        levelOneCompletedDeaths = playerController.levelOneCompletedDeaths;
        levelTwoCompletedDeaths = playerController.levelTwoCompletedDeaths;
        levelThreeCompletedDeaths = playerController.levelThreeCompletedDeaths;

        levelOneComplete = playerController.levelOneComplete;
        levelTwoComplete = playerController.levelTwoComplete;
        levelThreeComplete = playerController.levelThreeComplete;

        levelOneCompletePercentage = playerController.levelOneCompletePercentage;
        levelTwoCompletePercentage = playerController.levelTwoCompletePercentage;
        levelThreeCompletePercentage = playerController.levelThreeCompletePercentage;
      
        adsWatched = playerController.adsWatched;

        healthFour = playerController.healthFour;
        healthFive = playerController.healthFive;
        healthSix = playerController.healthSix;

        musicVolume = playerController.musicVolume;
        soundVolume = playerController.soundVolume;

    }


    void UpdateToSave()
    {
        playerController.levelOneDeaths = levelOneDeaths;
        playerController.levelTwoDeaths = levelTwoDeaths;
        playerController.levelThreeDeaths = levelThreeDeaths;

        playerController.levelOneCompletedDeaths = levelOneCompletedDeaths;
        playerController.levelTwoCompletedDeaths = levelTwoCompletedDeaths;
        playerController.levelThreeCompletedDeaths = levelThreeCompletedDeaths;

        playerController.levelOneComplete = levelOneComplete;
        playerController.levelTwoComplete = levelTwoComplete;
        playerController.levelThreeComplete = levelThreeComplete;

        playerController.levelOneCompletePercentage = levelOneCompletePercentage;
        playerController.levelTwoCompletePercentage = levelTwoCompletePercentage;
        playerController.levelThreeCompletePercentage = levelThreeCompletePercentage;

        playerController.adsWatched = adsWatched;

        playerController.healthFour = healthFour;
        playerController.healthFive = healthFive;
        playerController.healthSix = healthSix;

        playerController.musicVolume = musicVolume;
        playerController.soundVolume = soundVolume;       

    }


    public void SaveGameToMain()
    {
        UpdateToSave();
        playerController.SaveGame();
    }



    public void SpeedUpParticleEffect(float theSpeed)
    {
        playerController.SpeedUpParticleEffect(theSpeed);
    }

    public void SpeedDownParticleEffect(float theSpeed)
    {
        playerController.SpeedDownParticleEffect(theSpeed);
    }



    ///////////////////////
    /// Scene Managment ///
    ///////////////////////


    public void LoadingToMenuSceneAsync()
    {
        playerController.LoadingToMenuSceneAsync();
    }

    public void LoadingToLevelOneSceneAsync()
    {
        playerController.LoadingToLevelOneSceneAsync();
    }

    public void LoadingToLevelTwoSceneAsync()
    {
        playerController.LoadingToLevelTwoSceneAsync();
    }

    public void LoadingToLevelThreeSceneAsync()
    {
        playerController.LoadingToLevelThreeSceneAsync();
    }

    public void TryAgain()
    {
        if (playerController.timerCount >= 240)
        {
            Debug.Log(playerController.timerCount);
            PlayAd();
            playerController.timerCount = 0;
        }

        else if (playerController.timerCount < 240)
        {
            playerController.TryAgain();
        }
    }






    ///////////////////////
    /// Audio Managment ///
    ///////////////////////


    public void UpdateMusicSliders()
    {
        musicSlider.value = musicVolume;
    }

    public void UpdateSoundSliders()
    {
        soundSlider.value = soundVolume;
    }



    public void AdjustMusicVolume(Slider slider)
    {
        musicVolume = slider.value;

        playerController.AdjustMusicVolume(musicVolume);
    }

    public void AdjustSoundVolume(Slider slider)
    {
        soundVolume = slider.value;

        playerController.AdjustSoundVolume(soundVolume);
    }


    //////////////
    /// Music ///
    /////////////



    public void MusicThemeOne()
    {
        playerController.MusicThemeOne();
    }

    public void StopMusicAndSoundThemeOne()
    {
        playerController.StopMusicAndSoundThemeOne();
    }



    public void MusicThemeTwo()
    {
        playerController.MusicThemeTwo();
    }
    public void StopMusicAndSoundThemeTwo()
    {
        playerController.StopMusicAndSoundThemeTwo();
    }




    public void MusicLevelOne()
    {
        playerController.MusicLevelOne();
    }

    public void StopMusicAndSoundLevelOne()
    {
        playerController.StopMusicAndSoundLevelOne();
    }




    public void MusicLevelTwo()
    {
        playerController.MusicLevelTwo();
    }
    public void StopMusicAndSoundLevelTwo()
    {
        playerController.StopMusicAndSoundLevelTwo();
    }



    public void MusicLevelThree()
    {
        playerController.MusicLevelThree();
    }

    public void StopMusicAndSoundLevelThree()
    {
        playerController.StopMusicAndSoundLevelThree();
    }



    public void MusicWind()
    {
        playerController.MusicWind();
    }

    public void StopMusicAndSoundWind()
    {
        playerController.StopMusicAndSoundWind();
    }

    public void StopMusicAndSoundWindCompletely()
    {
        playerController.StopMusicAndSoundWindCompletely();
    }





    //////////////
    /// Sound ///
    /////////////



    public void SoundTurnPage()
    {
        playerController.SoundTurnPage();
    }

    public void SoundSelectLevel()
    {
        playerController.SoundSelectLevel();
    }

    public void SoundHit()
    {
        playerController.SoundHit();
    }

    public void SoundDying()
    {
        playerController.SoundDying();
    }

    public void SoundCoin()
    {
        playerController.SoundCoin();
    }

    public void SoundTeleport()
    {
        playerController.SoundTeleport();
    }




    //////////////
    ///  Ads  ///
    /////////////


    
    public void PlayAd()
    {
        ShowRegularAd(OnAdClosed);
    }

    public void PlayRewardedAd()
    {
        ShowRewardedAd(OnRewardedAdClosed);
    }

    void OnAdClosed (ShowResult result)
    {
        adsWatched += 1;
        SaveGameToMain();
        playerController.TryAgain();
        Debug.Log("Regular Ad Closed");
    }

    void OnRewardedAdClosed(ShowResult result)
    {
        Debug.Log("Rewarded Ad Closed");

        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Ad Finished, reward Player");
                adsWatched += 1;
                menuController.UpdateAdsViewed();
                SaveGameToMain();
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad Skipped");
                break;
            case ShowResult.Failed:
                Debug.Log("Works on my machine");
                break;
        }
    }


    void ShowRegularAd(System.Action<ShowResult> callBack)
    {
        if (Advertisement.IsReady(regularPlacementID))
        {
            ShowOptions so = new ShowOptions();
            so.resultCallback = callBack;
            Advertisement.Show(regularPlacementID, so);
        }
        else
        {
            Debug.Log("Ad not Ready or Net off");
        }
    }


    void ShowRewardedAd(System.Action<ShowResult> callBack)
    {
        if (Advertisement.IsReady(rewardedVideoPlacementID))
        {
            ShowOptions so = new ShowOptions();
            so.resultCallback = callBack;
            Advertisement.Show(rewardedVideoPlacementID, so);
        }
        else
        {
            Debug.Log("Ad not Ready or Net off");
        }
    }


}
