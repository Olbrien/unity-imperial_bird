using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelMenu : MonoBehaviour
{
    public bool atLevelOne;
    public bool atLevelTwo;
    public bool atLevelThree;

    [Space(10)]

    public int coinsCollected;
    [HideInInspector]
    public int coinsTotal;

    [Space(20)]

    public TextMeshProUGUI coinsCollectedTotalText;

    public SceneLoader sceneLoader;
    BackgroundStuff backgroundStuff;
    public ObstaclesPool obstaclesPool;

    public Transform playerGameObject;
    public CameraScript cameraScript;
    public Player player;

    public Transform playerTransform;

    public Transform mainCameraTransform;
    public Transform backgroundCameraTransform;
    public Transform coinsCameraTransform;


    public Canvas clickToStartCanvas;
    public Transform clickToStartButtonGameObject;
    public CanvasGroup clickToStartCanvasGroup;

    public CanvasGroup buttonsCanvasGroup;
    public CanvasGroup menuCanvasGroup;

    public CanvasGroup healthCanvasGroup;
    public CanvasGroup progressBarCanvasGroup;
    public CanvasGroup coinsCanvasGroup;

    public Canvas diedCanvas;
    public CanvasGroup diedCanvasGroup;

    public Canvas madeItCanvas;
    public CanvasGroup madeItCanvasGroup;

    public Canvas madeItNoCoinsCanvas;
    public CanvasGroup madeItNoCoinsCanvasGroup;

    public PlayerControllerCollector playerControllerCollector;

    public TextMeshProUGUI totalDeathsText;


    float theTime;
    float theTimeTwo;

    Vector3 currentCameraPositionUp;
    Vector3 currentCameraPositionDown;
    Vector3 offScreenRight = new Vector3(546, 0, 0);
    Vector3 playerToStart = new Vector3(-4.7f, 0, 0);
    Vector3 toMainMenuPosition = new Vector3(-100, 0, 0);

    float stepOne;
    float stepTwo;
    int speedOne = 850;
    int speedTwo = 3;

    bool start;
    bool onClickClickToStartButton;
    public bool playerIsMoving;
    public bool playerStopMovingBeggining;
    int section;
    int sectionTwo;


    Vector3 menuUpPosition = new Vector3(0, 4.5f, -10);    
    Vector3 menuDownPosition = new Vector3(0, 0f, -10);

    bool menuIsClosed = true;
    bool menuIsOpened;
    bool openMenu;
    bool closeMenu;
    float stepThree;
    float speedThree = 15;


    bool mainMenu;

    bool youDied;

    bool tryAgain;

    bool youMadeIt;

    bool youMadeItNoCoins;

    bool particleSystemStart;

    bool updateSliders;

    bool updateSong;


    void Start()
    {
        backgroundStuff = GameObject.FindGameObjectWithTag("BackgroundStuff").GetComponent<BackgroundStuff>();

        buttonsCanvasGroup.blocksRaycasts = false;

        coinsTotal = obstaclesPool.coinsTotalCount.Count;
        UpdateCoinsCollected();

        clickToStartCanvasGroup.alpha = 0;
        buttonsCanvasGroup.alpha = 0;
        menuCanvasGroup.alpha = 0;
        healthCanvasGroup.alpha = 0;
        progressBarCanvasGroup.alpha = 0;
        coinsCanvasGroup.alpha = 0;

        if (backgroundStuff.comingFromLevel)
        {
            clickToStartCanvas.enabled = false;
            clickToStartCanvasGroup.enabled = false;
            onClickClickToStartButton = true;
            buttonsCanvasGroup.blocksRaycasts = true;
        }

        start = true;
        particleSystemStart = true;
        updateSliders = true;
        updateSong = true;
    }


    void Update()
    {
        if (start)
        {            
            if (particleSystemStart)
            {
                if (atLevelOne) { playerControllerCollector.SpeedUpParticleEffect(8); }
                else if (atLevelTwo) { playerControllerCollector.SpeedUpParticleEffect(16); }
                else if (atLevelThree) { playerControllerCollector.SpeedUpParticleEffect(14); }
                particleSystemStart = false;
            }

            if (updateSong)
            {
                playerControllerCollector.StopMusicAndSoundThemeOne();

                if (atLevelOne) { playerControllerCollector.MusicLevelOne(); }
                else if (atLevelTwo) { playerControllerCollector.MusicLevelTwo(); } 
                else if (atLevelThree) { playerControllerCollector.MusicLevelThree(); } 

                //playerControllerCollector.UpdateSongIsPlaying();

                //if (atLevelOne)
                //{
                //    if (playerControllerCollector.levelOneSongPlaying == false)
                //    {
                //        playerControllerCollector.StopMusicAndSoundThemeOne();
                //        playerControllerCollector.MusicLevelOne(); } 
                //}

                //else if (atLevelTwo)
                //{
                //    if (playerControllerCollector.levelTwoSongPlaying == false) {
                //        playerControllerCollector.StopMusicAndSoundThemeOne();
                //        playerControllerCollector.MusicLevelTwo(); }
                //}

                //else if (atLevelThree)
                //{
                //    if (playerControllerCollector.levelThreeSongPlaying == false) {
                //        playerControllerCollector.StopMusicAndSoundThemeOne();
                //        playerControllerCollector.MusicLevelThree(); }
                //}

                updateSong = false;
            }

            if (updateSliders)
            {
                playerControllerCollector.UpdateMusicSliders();
                playerControllerCollector.UpdateSoundSliders();
                updateSliders = false;
            }

            if (backgroundStuff.comingFromLevel == false)
            {
                clickToStartCanvasGroup.alpha += Time.deltaTime * 0.6f;
            }

            if (atLevelOne)
            {
                totalDeathsText.text = "Bird Nr. " + playerControllerCollector.levelOneDeaths.ToString();
            }

            else if (atLevelTwo)
            {
                totalDeathsText.text = "Bird Nr. " + playerControllerCollector.levelTwoDeaths.ToString();
            }

            else if (atLevelThree)
            {
                totalDeathsText.text = "Bird Nr. " + playerControllerCollector.levelThreeDeaths.ToString();
            }


            buttonsCanvasGroup.alpha += Time.deltaTime * 0.6f;
            menuCanvasGroup.alpha += Time.deltaTime * 0.6f;
            healthCanvasGroup.alpha += Time.deltaTime * 0.6f;
            progressBarCanvasGroup.alpha += Time.deltaTime * 0.6f;
            coinsCanvasGroup.alpha += Time.deltaTime * 0.6f;

            if (buttonsCanvasGroup.alpha == 1 && healthCanvasGroup.alpha == 1 &&
                progressBarCanvasGroup.alpha == 1 && coinsCanvasGroup.alpha == 1 && menuCanvasGroup.alpha == 1)
            {
                start = false;
            }
        }

        if (onClickClickToStartButton && section == 0)
        {
            stepOne = speedOne * Time.deltaTime;

            clickToStartButtonGameObject.localPosition = Vector3.MoveTowards(clickToStartButtonGameObject.localPosition, offScreenRight, stepOne);

            if (clickToStartButtonGameObject.localPosition.x >= 150)
            {                
                section += 1;                
            }
        }

        if (onClickClickToStartButton && section == 1)
        {
            stepOne = speedOne * Time.deltaTime;

            clickToStartButtonGameObject.localPosition = Vector3.MoveTowards(clickToStartButtonGameObject.localPosition, offScreenRight, stepOne);

            stepTwo = speedTwo * Time.deltaTime;

            if (playerStopMovingBeggining == false)
            {
                playerGameObject.position = Vector3.MoveTowards(playerGameObject.position, new Vector3(-4.7f, playerGameObject.position.y, playerGameObject.position.z) , stepTwo);
            }

            if (playerGameObject.position.x == -4.7f)
            {
                playerIsMoving = true;
                player.startMovingRight = true;
                cameraScript.followingPlayer = true;
                section = 0;
                clickToStartCanvas.enabled = false;                
                menuCanvasGroup.blocksRaycasts = true;
                onClickClickToStartButton = false;
            }
        }


        if (openMenu && sectionTwo == 0)
        {
            theTimeTwo += Time.deltaTime;

            if (theTimeTwo >= 0.03f)
            {
                if (playerIsMoving == false)
                {
                    currentCameraPositionUp = new Vector3(mainCameraTransform.position.x, menuUpPosition.y, mainCameraTransform.position.z);
                    currentCameraPositionDown = new Vector3(mainCameraTransform.position.x, menuDownPosition.y, mainCameraTransform.position.z);
                    sectionTwo += 1;
                    theTimeTwo = 0;
                }

                else if (playerIsMoving)
                {
                    cameraScript.followingPlayer = false;
                    currentCameraPositionUp = new Vector3(mainCameraTransform.position.x, menuUpPosition.y, mainCameraTransform.position.z);
                    currentCameraPositionDown = new Vector3(mainCameraTransform.position.x, menuDownPosition.y, mainCameraTransform.position.z);
                    sectionTwo += 1;
                    theTimeTwo = 0;
                }
            }
        }

        else if (openMenu && sectionTwo == 1)
        {
            stepThree = 30 * Time.deltaTime;

            mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, currentCameraPositionUp, stepThree);
            backgroundCameraTransform.position = Vector3.MoveTowards(backgroundCameraTransform.position, menuUpPosition, stepThree);
            coinsCameraTransform.position = Vector3.MoveTowards(coinsCameraTransform.position, menuUpPosition, stepThree);

            if (backgroundCameraTransform.position.y == 4.5f && mainCameraTransform.position.y == 4.5f && coinsCameraTransform.position.y == 4.5f)
            {
                if (playerIsMoving == false)
                {
                    menuCanvasGroup.blocksRaycasts = true;
                    openMenu = false;
                    menuIsClosed = false;
                    menuIsOpened = true;
                    sectionTwo = 0;
                }

                else if (playerIsMoving)
                {
                    menuCanvasGroup.blocksRaycasts = true;
                    openMenu = false;
                    menuIsClosed = false;
                    menuIsOpened = true;
                    sectionTwo = 0;
                }
            }
        }

        if (closeMenu)
        {
            stepThree = 30 * Time.deltaTime;

            mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, currentCameraPositionDown, stepThree);
            backgroundCameraTransform.position = Vector3.MoveTowards(backgroundCameraTransform.position, menuDownPosition, stepThree);
            coinsCameraTransform.position = Vector3.MoveTowards(coinsCameraTransform.position, menuDownPosition, stepThree);

            if (backgroundCameraTransform.position.y == 0f && mainCameraTransform.position.y == 0f && coinsCameraTransform.position.y == 0f)
            {
                if (player.isDead)
                {
                    menuCanvasGroup.blocksRaycasts = true;
                    diedCanvasGroup.blocksRaycasts = true;
                    player.onMenu = false;
                    closeMenu = false;
                    menuIsClosed = true;
                    menuIsOpened = false;
                    player.startMovingRight = false;
                    return;
                }

                if (playerIsMoving == false)
                {
                    buttonsCanvasGroup.blocksRaycasts = true;
                    menuCanvasGroup.blocksRaycasts = true;
                    clickToStartCanvasGroup.blocksRaycasts = true;
                    playerStopMovingBeggining = false;
                    player.onMenu = false;

                    closeMenu = false;
                    menuIsClosed = true;
                    menuIsOpened = false;
                }

                else if (playerIsMoving)
                {
                    buttonsCanvasGroup.blocksRaycasts = true;
                    menuCanvasGroup.blocksRaycasts = true;
                    closeMenu = false;
                    player.startMovingRight = true;
                    cameraScript.followingPlayer = true;
                    menuIsClosed = true;
                    menuIsOpened = false;
                    player.onMenu = false;
                }
            }
        }


        if (mainMenu)
        {
            youDied = false;
            start = false;
            clickToStartCanvasGroup.alpha -= Time.deltaTime * 0.8f;
            buttonsCanvasGroup.alpha -= Time.deltaTime * 0.8f;
            menuCanvasGroup.alpha -= Time.deltaTime * 0.8f;
            healthCanvasGroup.alpha -= Time.deltaTime * 0.8f;
            progressBarCanvasGroup.alpha -= Time.deltaTime * 0.8f;
            coinsCanvasGroup.alpha -= Time.deltaTime * 0.8f;

            if (diedCanvas.enabled)
            {
                diedCanvasGroup.alpha -= Time.deltaTime * 1.5f;
            }

            stepOne = 20 * Time.deltaTime;
            stepTwo = speedTwo * Time.deltaTime;

            mainCameraTransform.position = Vector3.MoveTowards(mainCameraTransform.position, toMainMenuPosition, stepOne);
            backgroundCameraTransform.position = Vector3.MoveTowards(backgroundCameraTransform.position, menuDownPosition, stepTwo);
            coinsCameraTransform.position = Vector3.MoveTowards(coinsCameraTransform.position, menuDownPosition, stepTwo);

            if (backgroundCameraTransform.position.y == 0 && coinsCameraTransform.position.y == 0)
            {
                if (backgroundStuff.changeToMenuAppearence == false)
                {                    
                    mainMenu = false;
                    diedCanvasGroup.alpha = 0;
                    playerControllerCollector.StopMusicAndSoundLevelThree();
                    playerControllerCollector.SaveGameToMain();
                    playerControllerCollector.LoadingToMenuSceneAsync();
                }
            }
        }



        if (youDied)
        {
            theTime += Time.deltaTime;

            if (theTime >= 0.4f)
            {
                buttonsCanvasGroup.alpha -= Time.deltaTime * 0.8f;
                diedCanvasGroup.alpha += Time.deltaTime * 0.6f;
            }

            if (diedCanvasGroup.alpha >= 0.2f && section == 0)
            {
                diedCanvasGroup.blocksRaycasts = true;
                menuCanvasGroup.blocksRaycasts = true;
                section += 1;
            }

            else if (diedCanvasGroup.alpha >= 0.5f && section == 1)
            {               
                diedCanvasGroup.blocksRaycasts = true;                
                section += 1;
            }


            else if (diedCanvasGroup.alpha == 1 && section == 2)
            { 
                youDied = false;

                section = 0;
            }
        }


        if (tryAgain && section == 0)
        {
            diedCanvasGroup.alpha -= Time.deltaTime * 1f;
            buttonsCanvasGroup.alpha -= Time.deltaTime * 1f;
            menuCanvasGroup.alpha -= Time.deltaTime * 1f;
            healthCanvasGroup.alpha -= Time.deltaTime * 1f;
            progressBarCanvasGroup.alpha -= Time.deltaTime * 1f;
            coinsCanvasGroup.alpha -= Time.deltaTime * 1f;

            if (diedCanvasGroup.alpha == 0 && buttonsCanvasGroup.alpha == 0 && menuCanvasGroup.alpha == 0 && healthCanvasGroup.alpha == 0
                && progressBarCanvasGroup.alpha == 0 && coinsCanvasGroup.alpha == 0)
            {
                playerControllerCollector.SaveGameToMain();
                playerControllerCollector.TryAgain();
                tryAgain = false;
            }
        }

        if (youMadeIt && section == 0)
        {
            buttonsCanvasGroup.alpha -= Time.deltaTime * 1f;
            menuCanvasGroup.alpha -= Time.deltaTime * 1f;
            healthCanvasGroup.alpha -= Time.deltaTime * 1f;
            coinsCanvasGroup.alpha -= Time.deltaTime * 1f;
            progressBarCanvasGroup.alpha -= Time.deltaTime * 1f;

            if (progressBarCanvasGroup.alpha == 0)
            {
                playerControllerCollector.StopMusicAndSoundWind();
                section += 1;
            }
        }

        else if (youMadeIt && section == 1)
        {
            madeItCanvasGroup.alpha += Time.deltaTime * 0.5f;

            if (madeItCanvasGroup.alpha == 1)
            {
                section += 1;
            }
        }

        else if (youMadeIt && section == 2)
        {
            theTime += Time.deltaTime;

            if (theTime >= 4)
            {
                madeItCanvasGroup.alpha -= Time.deltaTime * 0.7f;
                backgroundStuff.comingFromLevel = true;
                backgroundStuff.changeToMenuAppearence = true;

                if (madeItCanvasGroup.alpha == 0)
                {
                    if (atLevelOne) { playerControllerCollector.SpeedDownParticleEffect(4); }
                    else if (atLevelTwo) { playerControllerCollector.SpeedDownParticleEffect(18); }
                    else if (atLevelThree) { playerControllerCollector.SpeedDownParticleEffect(14); }
                    section += 1;
                }
            }
        }

        else if (youMadeIt && section == 3)
        {
            if (backgroundStuff.changeToMenuAppearence == false)
            {
                if (atLevelOne) { playerControllerCollector.StopMusicAndSoundLevelOne(); }
                else if (atLevelTwo) { playerControllerCollector.StopMusicAndSoundLevelTwo(); }
                else if (atLevelThree) { playerControllerCollector.StopMusicAndSoundLevelThree(); }
                playerControllerCollector.SaveGameToMain();
                playerControllerCollector.StopMusicAndSoundWind();
                playerControllerCollector.StopMusicAndSoundLevelThree();
                playerControllerCollector.LoadingToMenuSceneAsync();
                youMadeIt = false;
            }
        }



        if (youMadeItNoCoins && section == 0)
        {
            buttonsCanvasGroup.alpha -= Time.deltaTime * 1f;
            menuCanvasGroup.alpha -= Time.deltaTime * 1f;
            healthCanvasGroup.alpha -= Time.deltaTime * 1f;
            coinsCanvasGroup.alpha -= Time.deltaTime * 1f;
            progressBarCanvasGroup.alpha -= Time.deltaTime * 1f;
            

            if (progressBarCanvasGroup.alpha == 0)
            {
                playerControllerCollector.StopMusicAndSoundWind();
                section += 1;
            }
        }

        else if (youMadeItNoCoins && section == 1)
        {
            madeItNoCoinsCanvasGroup.alpha += Time.deltaTime * 0.5f;

            if (madeItNoCoinsCanvasGroup.alpha == 1)
            {
                section += 1;
            }
        }

        else if (youMadeItNoCoins && section == 2)
        {
            theTime += Time.deltaTime;

            if (theTime >= 4)
            {
                madeItNoCoinsCanvasGroup.alpha -= Time.deltaTime * 0.7f;

                if (madeItNoCoinsCanvasGroup.alpha == 0)
                {
                    if (atLevelOne) { playerControllerCollector.SpeedDownParticleEffect(4); }
                    else if (atLevelTwo) { playerControllerCollector.SpeedDownParticleEffect(18); }
                    else if (atLevelThree) { playerControllerCollector.SpeedDownParticleEffect(14); }
                    section += 1;
                }
            }
        }

        else if (youMadeItNoCoins && section == 3)
        {
            playerControllerCollector.StopMusicAndSoundLevelThree();
            playerControllerCollector.SaveGameToMain();
            playerControllerCollector.TryAgain();
            youMadeItNoCoins = false;
        }
    }



    public void OnClickClickToStart()
    {
        buttonsCanvasGroup.blocksRaycasts = true;
        clickToStartCanvasGroup.blocksRaycasts = false;
        onClickClickToStartButton = true;
    }


    public void OnClickMenu()
    {
        //playerControllerCollector.SoundTurnPage();

        player.onMenu = true;

        if (playerIsMoving == false)
        {
            buttonsCanvasGroup.blocksRaycasts = false;
            menuCanvasGroup.blocksRaycasts = false;
            clickToStartCanvasGroup.blocksRaycasts = false;
            playerStopMovingBeggining = true;

            currentCameraPositionUp = new Vector3(mainCameraTransform.position.x, menuUpPosition.y, mainCameraTransform.position.z);
            currentCameraPositionDown = new Vector3(mainCameraTransform.position.x, menuDownPosition.y, mainCameraTransform.position.z);


            if (menuIsClosed)
            {
                openMenu = true;
            }

            if (menuIsOpened)
            {
                closeMenu = true;
            }

            return;
        }


        buttonsCanvasGroup.blocksRaycasts = false;
        menuCanvasGroup.blocksRaycasts = false;
        diedCanvasGroup.blocksRaycasts = false;

        player.startMovingRight = false;        

        if (menuIsClosed)
        {
            openMenu = true;
        }

        if (menuIsOpened)
        {
            closeMenu = true;
        }
    }



    public void OnClickMainMenu()
    {
        playerControllerCollector.SoundSelectLevel();
        playerControllerCollector.StopMusicAndSoundWindCompletely();
        if (atLevelOne) { playerControllerCollector.StopMusicAndSoundLevelOne(); }
        else if (atLevelTwo) { playerControllerCollector.StopMusicAndSoundLevelTwo(); }
        else if (atLevelThree) { playerControllerCollector.StopMusicAndSoundLevelThree(); }
        obstaclesPool.FadeOut();
        menuCanvasGroup.blocksRaycasts = false;
        diedCanvasGroup.blocksRaycasts = false;        
        backgroundStuff.comingFromLevel = true;
        backgroundStuff.changeToMenuAppearence = true;

        if (atLevelOne) { playerControllerCollector.SpeedDownParticleEffect(4); }
        else if (atLevelTwo) { playerControllerCollector.SpeedDownParticleEffect(18); }
        else if (atLevelThree) { playerControllerCollector.SpeedDownParticleEffect(14); }

        mainMenu = true;
    }



    public void UpdateCoinsCollected()
    {
        coinsCollectedTotalText.text = coinsCollected.ToString() + " / " + coinsTotal.ToString();
    }


    public void YouDied()
    {
        if (atLevelOne) { playerControllerCollector.StopMusicAndSoundLevelOne(); }
        else if (atLevelTwo) { playerControllerCollector.StopMusicAndSoundLevelTwo(); }
        else if (atLevelThree) { playerControllerCollector.StopMusicAndSoundLevelThree(); }
        playerControllerCollector.MusicWind();        
        buttonsCanvasGroup.blocksRaycasts = false;
        menuCanvasGroup.blocksRaycasts = false;
        diedCanvas.enabled = true;
        theTime = 0;

        youDied = true;
    }

    public void TryAgain()
    {
        playerControllerCollector.StopMusicAndSoundWind();
        playerControllerCollector.SpeedDownParticleEffect(16);
        menuCanvasGroup.blocksRaycasts = false;
        youDied = false;
        section = 0;
        backgroundStuff.comingFromLevel = true;
        diedCanvasGroup.blocksRaycasts = false;
        
        tryAgain = true;
    }


    public void YouMadeIt()
    {
        if (atLevelOne)
        {
            if (playerControllerCollector.levelOneComplete == false)
            {
                playerControllerCollector.levelOneComplete = true;
                playerControllerCollector.levelOneCompletedDeaths = playerControllerCollector.levelOneDeaths;
                playerControllerCollector.SaveGameToMain();
            }
        }

        else if (atLevelTwo)
        {
            if (playerControllerCollector.levelTwoComplete == false)
            {
                playerControllerCollector.levelTwoComplete = true;
                playerControllerCollector.levelTwoCompletedDeaths = playerControllerCollector.levelTwoDeaths;
                playerControllerCollector.SaveGameToMain();
            }
        }

        else if (atLevelThree)
        {
            if (playerControllerCollector.levelThreeComplete == false)
            {
                playerControllerCollector.levelThreeComplete = true;
                playerControllerCollector.levelThreeCompletedDeaths = playerControllerCollector.levelThreeDeaths;
                playerControllerCollector.SaveGameToMain();
            }
        }


        player.boxCollider2D.enabled = false;
        cameraScript.followingPlayer = false;
        buttonsCanvasGroup.blocksRaycasts = false;
        menuCanvasGroup.blocksRaycasts = false;
        player.speedRight = 16;
        obstaclesPool.FadeOut();

        madeItCanvas.enabled = true;

        theTime = 0;

        youMadeIt = true;
    }


    public void YouMadeItButNoCoins()
    {
        player.boxCollider2D.enabled = false;
        cameraScript.followingPlayer = false;
        buttonsCanvasGroup.blocksRaycasts = false;
        menuCanvasGroup.blocksRaycasts = false;
        player.speedRight = 16;
        obstaclesPool.FadeOut();

        madeItNoCoinsCanvas.enabled = true;

        theTime = 0;

        youMadeItNoCoins = true;

    }


    public void AddLifes()
    {
        player.health = 300;
    }

    public void SlowSpeed()
    {
        player.speedRight = 3;
    }



    public void CoinSound()
    {
        playerControllerCollector.SoundCoin();
    }

}

