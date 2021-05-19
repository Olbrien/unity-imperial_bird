using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
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



    public float timerCount;

    [Space(20)]

    public ParticleSystem particlesSystem;
    public AudioManager audioManager;
    ParticleSystem.MainModule main;
    public bool speedUpParticlesEffect;
    public bool speedDownParticlesEffect;
    public float speed;


    void Awake()
    {
        main = particlesSystem.main;

        DontDestroyOnLoad(gameObject);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;  // Isto é para ler o UpdateState sempre que 
                                                                             // muda a cena. Sem isto, o Start e Awake não 
                                                                             // funciona.
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        Quality();
        LoadGame();
    }



    void Quality()
    {
        //QualitySettings.vSyncCount = 1;
        //Application.targetFrameRate = 60;
    }



    void Update()
    {
        timerCount += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
            //Debug.Log("Game Loaded");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call<bool>("moveTaskToBack", true);            
        }

        if (Input.GetKeyDown(KeyCode.Home))
        {
            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call<bool>("moveTaskToBack", true);
        }

        if (Input.GetKeyDown(KeyCode.Menu))
        {
            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call<bool>("moveTaskToBack", true);
        }

        if (speedUpParticlesEffect)
        {
            main.simulationSpeed += 10 * Time.deltaTime; 

            if (main.simulationSpeed >= speed)
            {
                main.simulationSpeed = speed;
                speedUpParticlesEffect = false;
            }
        }

        if (speedDownParticlesEffect)
        {
            main.simulationSpeed -= speed * Time.deltaTime;

            if (main.simulationSpeed <= 0)
            {
                main.simulationSpeed = 0;
                speedDownParticlesEffect = false;
            }
        }

    }


    public void SaveGame()
    {
        SaveLoadManager.SavePlayerInt(this);
        SaveLoadManager.SavePlayerFloat(this);
        SaveLoadManager.SavePlayerBool(this);
        //Debug.Log("Saving Game");
    }

    public void LoadGame()
    {
        int[] loadedStatsInt = SaveLoadManager.LoadPlayerInt();

        levelOneDeaths = loadedStatsInt[0];
        levelTwoDeaths = loadedStatsInt[1];
        levelThreeDeaths = loadedStatsInt[2];

        levelOneCompletedDeaths = loadedStatsInt[3];
        levelTwoCompletedDeaths = loadedStatsInt[4];
        levelThreeCompletedDeaths = loadedStatsInt[5];

        adsWatched = loadedStatsInt[6];


        float[] loadedStatsFloat = SaveLoadManager.LoadPlayerFloat();

        levelOneCompletePercentage = loadedStatsFloat[0];
        levelTwoCompletePercentage = loadedStatsFloat[1];
        levelThreeCompletePercentage = loadedStatsFloat[2];

        musicVolume = loadedStatsFloat[3];
        soundVolume = loadedStatsFloat[4];


        bool[] loadedStatsBool = SaveLoadManager.LoadPlayerBool();

        levelOneComplete = loadedStatsBool[0];
        levelTwoComplete = loadedStatsBool[1];
        levelThreeComplete = loadedStatsBool[2];

        healthFour = loadedStatsBool[3];
        healthFive = loadedStatsBool[4];
        healthSix = loadedStatsBool[5];

    }



    public void SpeedUpParticleEffect(float theSpeed)
    {        
        speed = theSpeed;
        speedDownParticlesEffect = false;
        speedUpParticlesEffect = true;
    }

    public void SpeedDownParticleEffect(float theSpeed)
    {
        speed = theSpeed;
        speedUpParticlesEffect = false;
        speedDownParticlesEffect = true;
    }


    ///////////////////////
    /// Scene Managment ///
    ///////////////////////




    public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex + 1);
    }

    public void PreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex - 1);
    }

    public void LoadingToMenuSceneAsync()
    {
        StartCoroutine(LoadingToMenuSceneASyncCoroutine());
    }

    IEnumerator LoadingToMenuSceneASyncCoroutine()
    {
        while (main.simulationSpeed > 0.1f)
        {
            yield return null;
        }

        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(1);
        loadLevel.allowSceneActivation = false;

        while (!loadLevel.isDone)
        {
            if (loadLevel.progress >= 0.9f)
            {
                loadLevel.allowSceneActivation = true;
            }
            yield return null;
        }
    }


    public void LoadingToLevelOneSceneAsync()
    {
        StartCoroutine(LoadingToLevelOneSceneASyncCoroutine());
    }

    IEnumerator LoadingToLevelOneSceneASyncCoroutine()
    {
        while (main.simulationSpeed > 0.1f)
        {
            yield return null;
        }

        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(2);

        loadLevel.allowSceneActivation = false;

        while (!loadLevel.isDone)
        {
            if (loadLevel.progress >= 0.9f)
            {
                loadLevel.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    public void LoadingToLevelTwoSceneAsync()
    {
        StartCoroutine(LoadingToLevelTwoSceneASyncCoroutine());
    }

    IEnumerator LoadingToLevelTwoSceneASyncCoroutine()
    {
        while (main.simulationSpeed > 0.1f)
        {
            yield return null;
        }

        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(3);
        loadLevel.allowSceneActivation = false;

        while (!loadLevel.isDone)
        {
            if (loadLevel.progress >= 0.9f)
            {
                loadLevel.allowSceneActivation = true;
            }
            yield return null;
        }
    }


    public void LoadingToLevelThreeSceneAsync()
    {
        StartCoroutine(LoadingToLevelThreeSceneASyncCoroutine());
    }

    IEnumerator LoadingToLevelThreeSceneASyncCoroutine()
    {
        while (main.simulationSpeed > 0.1f)
        {
            yield return null;
        }

        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(4);
        loadLevel.allowSceneActivation = false;

        while (!loadLevel.isDone)
        {
            if (loadLevel.progress >= 0.9f)
            {
                loadLevel.allowSceneActivation = true;
            }
            yield return null;
        }
    }


    public void TryAgain()
    {
        StartCoroutine(LoadingToSameLevelSceneASyncCoroutine());
    }

    IEnumerator LoadingToSameLevelSceneASyncCoroutine()
    {
        while (main.simulationSpeed > 0.1f)
        {
            yield return null;
        }

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(currentSceneIndex);
        loadLevel.allowSceneActivation = false;

        while (!loadLevel.isDone)
        {
            if (loadLevel.progress >= 0.9f)
            {
                loadLevel.allowSceneActivation = true;
            }
            yield return null;
        }
    }




    ///////////////////////
    /// Audio Managment ///
    ///////////////////////


    public void AdjustMusicVolume(float value) 
    {
        audioManager.AdjustMusicVolume(value);
    }

    public void AdjustSoundVolume(float value)
    {
        audioManager.AdjustSoundVolume(value);
    }


    //////////////
    /// Music ///
    /////////////


    public void MusicThemeOne()
    {
        audioManager.PlayMusic("ThemeOne");
    }

    public void StopMusicAndSoundThemeOne()
    {
        audioManager.StopMusicAndSound("ThemeOne");
    }



    public void MusicThemeTwo()
    {
        audioManager.PlayMusic("ThemeTwo");
    }

    public void StopMusicAndSoundThemeTwo()
    {
        audioManager.StopMusicAndSound("ThemeTwo");
    }



    public void MusicLevelOne()
    {
        audioManager.PlayMusic("LevelOne");
    }

    public void StopMusicAndSoundLevelOne()
    {
        audioManager.StopMusicAndSound("LevelOne");
    }



    public void MusicLevelTwo()
    {
        audioManager.PlayMusic("LevelTwo");
    }
    public void StopMusicAndSoundLevelTwo()
    {
        audioManager.StopMusicAndSound("LevelTwo");
    }



    public void MusicLevelThree()
    {
        audioManager.PlayMusic("LevelThree");
    }
    public void StopMusicAndSoundLevelThree()
    {
        audioManager.StopMusicAndSound("LevelThree");
    }


    public void MusicWind()
    {
        audioManager.PlayMusic("Wind");
    }

    public void StopMusicAndSoundWind()
    {
        audioManager.StopMusicAndSound("Wind");
    }

    public void StopMusicAndSoundWindCompletely()
    {
        audioManager.StopMusicCompletely("Wind");
    }

    //////////////
    /// Sound ///
    /////////////



    public void SoundTurnPage()
    {
        audioManager.PlaySound("TurnPage");
    }

    public void SoundSelectLevel()
    {
        audioManager.PlaySound("SelectLevel");
    }

    public void SoundHit()
    {
        audioManager.PlaySound("Hit");
    }

    public void SoundDying()
    {
        audioManager.PlaySound("Dying");
    }

    public void SoundCoin()
    {
        audioManager.PlaySound("Coin");
    }

    public void SoundTeleport()
    {
        audioManager.PlaySound("Teleport");
    }
}
