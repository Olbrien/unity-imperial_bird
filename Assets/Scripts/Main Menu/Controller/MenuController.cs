using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public int adsForHealthFour;
    public int adsForHealthFive;
    public int adsForHealthSix;

    int adsCalculation;


    public PlayerControllerCollector playerControllerCollector;
    public SceneLoader sceneLoader;

    BackgroundStuff backgroundStuff;


    public Transform mainCameraTransform;
    public Transform imperialBirdCameraTransform;

    public Canvas blackScreenCanvas;
    public CanvasGroup blackScreenCanvasGroup;

    public Canvas mainMenuCanvas;
    public CanvasGroup mainMenuCanvasGroup;

    public Canvas healthCanvas;
    public CanvasGroup healthCanvasGroup;

    public Canvas settingsCanvas;
    public CanvasGroup settingsCanvasGroup;

    public Canvas creditsCanvas;
    public CanvasGroup creditsCanvasGroup;

    public GameObject resetButton;

    public Canvas resetCanvas;
    public CanvasGroup resetCanvasGroup;

    public TextMeshProUGUI levelOneBeatenText;
    public TextMeshProUGUI levelOneDeaths;

    public TextMeshProUGUI levelTwoBeatenText;
    public TextMeshProUGUI levelTwoDeaths;

    public TextMeshProUGUI levelThreeBeatenText;
    public TextMeshProUGUI levelThreeDeaths;

    public TextMeshProUGUI adsViewedTxt;

    public GameObject healthThreeHearts;
    public GameObject healthFourHearts;
    public GameObject healthFiveHearts;
    public GameObject healthSixHearts;

    bool intro;
    int introSection;

    Vector3 positionMinusTwo = new Vector3(-40, 0f, -10);
    Vector3 positionMinusOne = new Vector3(-20, 0f, -10);
    Vector3 positionZero = new Vector3(0, 0f, -10);
    Vector3 positionOne = new Vector3(20, 0f, -10);
    Vector3 positionTwo = new Vector3(40, 0f, -10);
    Vector3 positionThree = new Vector3(60, 0f, -10);
    Vector3 positionFour = new Vector3(80, 0f, -10);
    Vector3 positionFive = new Vector3(100, 0f, -10);

    float speed = 40;
    float step;

    bool onClickHealth;
    bool onClickBackFromHealth;
    bool onClickSettings;
    bool onClickBackFromSettings;
    bool onClickCredits;
    bool onClickBackFromCredits;
    bool onClickReset;
    bool onClickBackFromReset;
    bool onClickReallyReset;

    bool onClickLevelOne;
    bool onClickLevelTwo;
    bool onClickLevelThree;

    bool start = true;

    int randomNumber;

    float theTime;


    void Start()
    {
        backgroundStuff = GameObject.FindGameObjectWithTag("BackgroundStuff").GetComponent<BackgroundStuff>();

        Intro();
    }



    void Update()
    {
        if (start)
        {
            playerControllerCollector.SpeedUpParticleEffect(6);
            UpdateAdsViewed();
            playerControllerCollector.UpdateMusicSliders();
            playerControllerCollector.UpdateSoundSliders();
            playerControllerCollector.MusicThemeOne();
            UpdateMainMenu();
        }

        if (intro)
        {
            IntroAnimation();
        }

        if (onClickHealth)
        {
            ToHealthFromMainMenu();
        }

        if (onClickSettings)
        {
            ToSettingsFromHealth();
        }

        if (onClickCredits)
        {
            ToCreditsFromSettings();
        }

        if (onClickBackFromCredits)
        {
            ToSettingsFromCredits();
        }

        if (onClickBackFromSettings)
        {
            ToHealthFromSettings();
        }

        if (onClickReset)
        {
            ToResetFromCredits();
        }

        if (onClickBackFromReset)
        {
            ToCreditsFromReset();
        }

        if (onClickBackFromHealth)
        {
            ToMainMenuFromHealth();
        }

        if (onClickReallyReset)
        {
            OnClickReallyResetAction();
        }

        if (onClickLevelOne)
        {
            OnClickLevelOneAction();
        }

        if (onClickLevelTwo)
        {
            OnClickLevelTwoAction();
        }

        if (onClickLevelThree)
        {
            OnClickLevelThreeAction();
        }

    }




    void Intro()
    {
        blackScreenCanvasGroup.alpha = 1;
        introSection = 0;

        imperialBirdCameraTransform.position = positionMinusOne;
        mainCameraTransform.position = positionMinusOne;

        mainMenuCanvasGroup.blocksRaycasts = false;

        intro = true;
    }

    void IntroAnimation()
    {
        if (intro && introSection == 0)
        {
            if (backgroundStuff.comingFromLevel)
            {                
                blackScreenCanvasGroup.alpha = 0;
                blackScreenCanvas.enabled = false;

                theTime += Time.deltaTime;

                if (theTime >= 1.22f)
                {
                    step = 25 * Time.deltaTime;
                    imperialBirdCameraTransform.position = Vector3.MoveTowards(imperialBirdCameraTransform.position, positionZero, step);
                    mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, positionZero, step);

                    if (imperialBirdCameraTransform.position.x == 0f && mainCameraTransform.position.x == 0f)
                    {
                        backgroundStuff.comingFromLevel = false;
                        introSection += 1;
                        theTime = 0;
                    }
                }
            }

            else if (backgroundStuff.comingFromLevel == false)
            {
                blackScreenCanvasGroup.alpha -= Time.deltaTime * 0.72f;

                if (blackScreenCanvasGroup.alpha == 0 && backgroundStuff.comingFromLevel == false)
                {
                    blackScreenCanvas.enabled = false;
                    introSection += 1;
                }
            }
        }

        else if (intro && introSection == 1)
        {
            step = 25 * Time.deltaTime;
            imperialBirdCameraTransform.position = Vector3.MoveTowards(imperialBirdCameraTransform.position, positionZero, step);
            mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, positionZero, step);

            if (imperialBirdCameraTransform.position.x == 0f && mainCameraTransform.position.x == 0f)
            {
                mainMenuCanvasGroup.blocksRaycasts = true;
                intro = false;
                introSection = 0;
            }
        }
    }



    void UpdateMainMenu()
    {
        if (playerControllerCollector.levelOneComplete)
        {
            levelOneBeatenText.text = "BEATEN!!!!";
            levelOneDeaths.text = "With " + playerControllerCollector.levelOneCompletedDeaths.ToString() + " Deaths!!";
        }

        else if (playerControllerCollector.levelOneComplete == false)
        {
            levelOneBeatenText.text = "Unbeaten!";
            levelOneDeaths.text = playerControllerCollector.levelOneDeaths.ToString() + " Deaths";
        }


        if (playerControllerCollector.levelTwoComplete)
        {
            levelTwoBeatenText.text = "BEATEN!!!!";
            levelTwoDeaths.text = "With " + playerControllerCollector.levelTwoCompletedDeaths.ToString() + " Deaths!!";
        }

        else if (playerControllerCollector.levelTwoComplete == false)
        {
            levelTwoBeatenText.text = "Unbeaten!";
            levelTwoDeaths.text = playerControllerCollector.levelTwoDeaths.ToString() + " Deaths";
        }


        if (playerControllerCollector.levelThreeComplete)
        {
            levelThreeBeatenText.text = "BEATEN!!!!";
            levelThreeDeaths.text = "With " + playerControllerCollector.levelThreeCompletedDeaths.ToString() + " Deaths!!";
        }

        else if (playerControllerCollector.levelThreeComplete == false)
        {
            levelThreeBeatenText.text = "Unbeaten!";
            levelThreeDeaths.text = playerControllerCollector.levelThreeDeaths.ToString() + " Deaths";
        }


        if (playerControllerCollector.levelOneComplete && playerControllerCollector.levelTwoComplete &&
            playerControllerCollector.levelThreeComplete)
        {
            resetButton.SetActive(true);
        }


        start = false;
    }




    public void OnClickHealth()
    {
        mainMenuCanvasGroup.blocksRaycasts = false;
        healthCanvasGroup.blocksRaycasts = false;
        //playerControllerCollector.SoundTurnPage();
        onClickHealth = true;
    }

    void ToHealthFromMainMenu()
    {
        if (onClickHealth && introSection == 0)
        {
            step = speed * Time.deltaTime;

            mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, positionOne, step);
            imperialBirdCameraTransform.position = Vector3.MoveTowards(imperialBirdCameraTransform.position, positionOne, step);

            if (mainCameraTransform.position.x == 20 && imperialBirdCameraTransform.position.x == 20)
            {
                healthCanvasGroup.blocksRaycasts = true;
                onClickHealth = false;
                introSection = 0;
            }
        }
    }


    public void OnClickBackFromHealth()
    {
        healthCanvasGroup.blocksRaycasts = false;
        mainMenuCanvasGroup.blocksRaycasts = false;
        //playerControllerCollector.SoundTurnPage();
        onClickBackFromHealth = true;
    }


    void ToMainMenuFromHealth()
    {
        if (onClickBackFromHealth && introSection == 0)
        {
            step = speed * Time.deltaTime;

            mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, positionZero, step);
            imperialBirdCameraTransform.position = Vector3.MoveTowards(imperialBirdCameraTransform.position, positionZero, step);

            if (mainCameraTransform.position.x == 0 && imperialBirdCameraTransform.position.x == 0)
            {
                mainMenuCanvasGroup.blocksRaycasts = true;
                onClickBackFromHealth = false;
                introSection = 0;
            }
        }
    }




    public void OnClickSettings()
    {
        settingsCanvasGroup.blocksRaycasts = false;
        healthCanvasGroup.blocksRaycasts = false;
        //playerControllerCollector.SoundTurnPage();
        onClickSettings = true;
    }


    void ToSettingsFromHealth()
    {
        if (onClickSettings && introSection == 0)
        {
            step = speed * Time.deltaTime;

            mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, positionTwo, step);
            imperialBirdCameraTransform.position = Vector3.MoveTowards(imperialBirdCameraTransform.position, positionTwo, step);

            if (mainCameraTransform.position.x == 40 && imperialBirdCameraTransform.position.x == 40)
            {
                settingsCanvasGroup.blocksRaycasts = true;
                onClickSettings = false;
                introSection = 0;
            }
        }
    }



    public void OnClickCredits()
    {
        settingsCanvasGroup.blocksRaycasts = false;
        creditsCanvasGroup.blocksRaycasts = false;
        //playerControllerCollector.SoundTurnPage();
        onClickCredits = true;
    }


    void ToCreditsFromSettings()
    {
        if (onClickCredits && introSection == 0)
        {
            step = speed * Time.deltaTime;
            
            mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, positionThree, step);
            imperialBirdCameraTransform.position = Vector3.MoveTowards(imperialBirdCameraTransform.position, positionThree, step);

            if (mainCameraTransform.position.x == 60 && imperialBirdCameraTransform.position.x == 60)
            {
                creditsCanvasGroup.blocksRaycasts = true;
                onClickCredits = false;
                introSection = 0;
            }
        }
    }



    public void OnClickBackFromCredits()
    {
        settingsCanvasGroup.blocksRaycasts = false;
        creditsCanvasGroup.blocksRaycasts = false;
        //playerControllerCollector.SoundTurnPage();
        onClickBackFromCredits = true;
    }


    void ToSettingsFromCredits()
    {
        if (onClickBackFromCredits && introSection == 0)
        {
            step = speed * Time.deltaTime;

            mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, positionTwo, step);
            imperialBirdCameraTransform.position = Vector3.MoveTowards(imperialBirdCameraTransform.position, positionTwo, step);

            if (mainCameraTransform.position.x == 40 && imperialBirdCameraTransform.position.x == 40)
            {
                settingsCanvasGroup.blocksRaycasts = true;
                onClickBackFromCredits = false;
                introSection = 0;
            }
        }
    }



    public void OnClickBackFromSettings()
    {
        settingsCanvasGroup.blocksRaycasts = false;
        healthCanvasGroup.blocksRaycasts = false;
        //playerControllerCollector.SoundTurnPage();
        onClickBackFromSettings = true;
    }


    void ToHealthFromSettings()
    {
        if (onClickBackFromSettings && introSection == 0)
        {
            step = speed * Time.deltaTime;

            mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, positionOne, step);
            imperialBirdCameraTransform.position = Vector3.MoveTowards(imperialBirdCameraTransform.position, positionOne, step);

            if (mainCameraTransform.position.x == 20 && imperialBirdCameraTransform.position.x == 20)
            {
                healthCanvasGroup.blocksRaycasts = true;
                onClickBackFromSettings = false;
                introSection = 0;
            }
        }
    }



    public void OnClickReset()
    {
        creditsCanvasGroup.blocksRaycasts = false;
        resetCanvasGroup.blocksRaycasts = false;
        //playerControllerCollector.SoundTurnPage();
        onClickReset = true;
    }

    void ToResetFromCredits()
    {
        if (onClickReset && introSection == 0)
        {
            step = speed * Time.deltaTime;

            mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, positionFour, step);
            imperialBirdCameraTransform.position = Vector3.MoveTowards(imperialBirdCameraTransform.position, positionFour, step);

            if (mainCameraTransform.position.x == 80 && imperialBirdCameraTransform.position.x == 80)
            {
                resetCanvasGroup.blocksRaycasts = true;
                onClickReset = false;
                introSection = 0;
            }
        }
    }


    public void OnClickBackFromReset()
    {
        creditsCanvasGroup.blocksRaycasts = false;
        resetCanvasGroup.blocksRaycasts = false;
        //playerControllerCollector.SoundTurnPage();
        onClickBackFromReset = true;
    }

    void ToCreditsFromReset()
    {
        if (onClickBackFromReset && introSection == 0)
        {
            step = speed * Time.deltaTime;

            mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, positionThree, step);
            imperialBirdCameraTransform.position = Vector3.MoveTowards(imperialBirdCameraTransform.position, positionThree, step);

            if (mainCameraTransform.position.x == 60 && imperialBirdCameraTransform.position.x == 60)
            {
                creditsCanvasGroup.blocksRaycasts = true;
                onClickBackFromReset = false;
                introSection = 0;
            }
        }
    }




    public void OnClickReallyReset()
    {
        resetCanvasGroup.blocksRaycasts = false;
        blackScreenCanvas.enabled = true;
        playerControllerCollector.SpeedDownParticleEffect(4.3f);
        //playerControllerCollector.SoundTurnPage();
        onClickReallyReset = true;
    }

    void OnClickReallyResetAction()
    {
        if (onClickReallyReset && introSection == 0)
        {
            blackScreenCanvasGroup.alpha += Time.deltaTime * 0.4f;

            step = (speed + 10) * Time.deltaTime;
            mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, positionFive, step);
            imperialBirdCameraTransform.position = Vector3.MoveTowards(imperialBirdCameraTransform.position, positionFive, step);

            if (blackScreenCanvasGroup.alpha == 1)
            {
                playerControllerCollector.levelOneComplete = false;
                playerControllerCollector.levelTwoComplete = false;
                playerControllerCollector.levelThreeComplete = false;

                playerControllerCollector.levelOneDeaths = 0;
                playerControllerCollector.levelTwoDeaths = 0;
                playerControllerCollector.levelThreeDeaths = 0;

                playerControllerCollector.levelOneCompletedDeaths = 0;
                playerControllerCollector.levelTwoCompletedDeaths = 0;
                playerControllerCollector.levelThreeCompletedDeaths = 0;

                playerControllerCollector.levelOneCompletePercentage = 0;
                playerControllerCollector.levelTwoCompletePercentage = 0;
                playerControllerCollector.levelThreeCompletePercentage = 0;

                playerControllerCollector.SaveGameToMain();

                introSection += 1;

                playerControllerCollector.LoadingToMenuSceneAsync();
            }
        }
    }



    public void OnClickLevelOne()
    {
        mainMenuCanvasGroup.blocksRaycasts = false;
        playerControllerCollector.SoundSelectLevel();
        playerControllerCollector.StopMusicAndSoundThemeOne();
        onClickLevelOne = true;
    }

    void OnClickLevelOneAction()
    {
        if (onClickLevelOne && introSection == 0)
        {
            step = 20 * Time.deltaTime;
            mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, positionMinusOne, step);
            imperialBirdCameraTransform.position = Vector3.MoveTowards(imperialBirdCameraTransform.position, positionMinusOne, step);

            if (mainCameraTransform.position.x == -20 && imperialBirdCameraTransform.position.x == -20)
            {
                backgroundStuff.changeToLevelAppearence = true;
                playerControllerCollector.SpeedDownParticleEffect(4.3f);

                introSection += 1;
            }
        }

        else if (onClickLevelOne && introSection == 1)
        {
            if (backgroundStuff.changeToLevelAppearence == false)
            {
                introSection = 0;

                playerControllerCollector.SaveGameToMain();
                playerControllerCollector.LoadingToLevelOneSceneAsync();

                onClickLevelOne = false;                
            }
        }


    }


    public void OnClickLevelTwo()
    {
        mainMenuCanvasGroup.blocksRaycasts = false;
        playerControllerCollector.SoundSelectLevel();
        playerControllerCollector.StopMusicAndSoundThemeOne();
        onClickLevelTwo = true;
    }


    void OnClickLevelTwoAction()
    {
        if (onClickLevelTwo && introSection == 0)
        {
            step = 20 * Time.deltaTime;
            mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, positionMinusOne, step);
            imperialBirdCameraTransform.position = Vector3.MoveTowards(imperialBirdCameraTransform.position, positionMinusOne, step);

            if (mainCameraTransform.position.x == -20 && imperialBirdCameraTransform.position.x == -20)
            {
                backgroundStuff.changeToLevelAppearence = true;
                playerControllerCollector.SpeedDownParticleEffect(4.3f);

                introSection += 1;
            }
        }

        else if (onClickLevelTwo && introSection == 1)
        {
            if (backgroundStuff.changeToLevelAppearence == false)
            {
                introSection = 0;
                playerControllerCollector.SaveGameToMain();
                playerControllerCollector.LoadingToLevelTwoSceneAsync();

                onClickLevelTwo = false;
            }
        }

    }



    public void OnClickLevelThree()
    {
        mainMenuCanvasGroup.blocksRaycasts = false;
        playerControllerCollector.SoundSelectLevel();
        playerControllerCollector.StopMusicAndSoundThemeOne();
        onClickLevelThree = true;
    }


    void OnClickLevelThreeAction()
    {
        if (onClickLevelThree && introSection == 0)
        {
            step = 20 * Time.deltaTime;
            mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, positionMinusOne, step);
            imperialBirdCameraTransform.position = Vector3.MoveTowards(imperialBirdCameraTransform.position, positionMinusOne, step);

            if (mainCameraTransform.position.x == -20 && imperialBirdCameraTransform.position.x == -20)
            {
                backgroundStuff.changeToLevelAppearence = true;
                playerControllerCollector.SpeedDownParticleEffect(4.3f);                

                introSection += 1;
            }
        }

        else if (onClickLevelThree && introSection == 1)
        {
            if (backgroundStuff.changeToLevelAppearence == false)
            {
                introSection = 0;
                playerControllerCollector.SaveGameToMain();
                playerControllerCollector.LoadingToLevelThreeSceneAsync();

                onClickLevelThree = false;
            }
        }
    }


    public void UpdateAdsViewed()
    {
        if (playerControllerCollector.adsWatched >= adsForHealthFour && !playerControllerCollector.healthFour && !playerControllerCollector.healthFive
                                                                                                              && !playerControllerCollector.healthSix)
        {
            playerControllerCollector.healthFour = true;
            UpdateAdsViewed();
            playerControllerCollector.SaveGameToMain();
        }

        if (playerControllerCollector.adsWatched >= adsForHealthFive && playerControllerCollector.healthFour && !playerControllerCollector.healthFive
                                                                                                      && !playerControllerCollector.healthSix)
        {
            playerControllerCollector.healthFive = true;
            UpdateAdsViewed();
            playerControllerCollector.SaveGameToMain();
        }

        if (playerControllerCollector.adsWatched >= adsForHealthSix && playerControllerCollector.healthFour && playerControllerCollector.healthFive
                                                                                              && !playerControllerCollector.healthSix)
        {
            playerControllerCollector.healthSix = true;
            UpdateAdsViewed();
            playerControllerCollector.SaveGameToMain();
        }


        if (!playerControllerCollector.healthFour && !playerControllerCollector.healthFive && !playerControllerCollector.healthSix)
        {
            adsCalculation = adsForHealthFour - playerControllerCollector.adsWatched;
            adsViewedTxt.text = "<color=#FDFC09>" + "+" + adsCalculation + " Ads</color>" + " for the next Health Upgrade!!";
        }

        else if (playerControllerCollector.healthFour && !playerControllerCollector.healthFive && !playerControllerCollector.healthSix)
        {
            adsCalculation = adsForHealthFive - playerControllerCollector.adsWatched;
            adsViewedTxt.text = "<color=#FDFC09>" + "+" + adsCalculation + " Ads</color>" + " for the next Health Upgrade!!";
        }

        else if (playerControllerCollector.healthFour && playerControllerCollector.healthFive && !playerControllerCollector.healthSix)
        {
            adsCalculation = adsForHealthSix - playerControllerCollector.adsWatched;
            adsViewedTxt.text = "<color=#FDFC09>" + "+" + adsCalculation + " Ads</color>" + " for the next Health Upgrade!!";
        }

        else if (playerControllerCollector.healthFour && playerControllerCollector.healthFive && playerControllerCollector.healthSix)
        {
            adsViewedTxt.text = "You have all the Health Upgrades.";
        }


        if (!playerControllerCollector.healthFour && !playerControllerCollector.healthFive && !playerControllerCollector.healthSix)
        {
            healthThreeHearts.SetActive(true);
            healthFourHearts.SetActive(false);
            healthFiveHearts.SetActive(false);
            healthSixHearts.SetActive(false);
        }

        else if (playerControllerCollector.healthFour && !playerControllerCollector.healthFive && !playerControllerCollector.healthSix)
        {
            healthThreeHearts.SetActive(false);
            healthFourHearts.SetActive(true);
            healthFiveHearts.SetActive(false);
            healthSixHearts.SetActive(false);
        }

        else if (playerControllerCollector.healthFour && playerControllerCollector.healthFive && !playerControllerCollector.healthSix)
        {
            healthThreeHearts.SetActive(false);
            healthFourHearts.SetActive(false);
            healthFiveHearts.SetActive(true);
            healthSixHearts.SetActive(false);
        }

        else if (playerControllerCollector.healthFour && playerControllerCollector.healthFive && playerControllerCollector.healthSix)
        {
            healthThreeHearts.SetActive(false);
            healthFourHearts.SetActive(false);
            healthFiveHearts.SetActive(false);
            healthSixHearts.SetActive(true);
        }
    }
}
