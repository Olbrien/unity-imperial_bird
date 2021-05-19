using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
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
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(1);

        while (loadLevel.progress < 1)
        {
            yield return new WaitForEndOfFrame();
        }
    }


    public void LoadingToLevelOneSceneAsync()
    {
        StartCoroutine(LoadingToLevelOneSceneASyncCoroutine());
    }

    IEnumerator LoadingToLevelOneSceneASyncCoroutine()
    {
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(2);

        while (loadLevel.progress < 1)
        {
            yield return new WaitForEndOfFrame();
        }
    }

    public void LoadingToLevelTwoSceneAsync()
    {
        StartCoroutine(LoadingToLevelTwoSceneASyncCoroutine());
    }

    IEnumerator LoadingToLevelTwoSceneASyncCoroutine()
    {
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(3);

        while (loadLevel.progress < 1)
        {
            yield return new WaitForEndOfFrame();
        }
    }


    public void LoadingToLevelThreeSceneAsync()
    {
        StartCoroutine(LoadingToLevelThreeSceneASyncCoroutine());
    }

    IEnumerator LoadingToLevelThreeSceneASyncCoroutine()
    {
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(4);

        while (loadLevel.progress < 1)
        {
            yield return new WaitForEndOfFrame();
        }
    }


    public void TryAgain()
    {
        StartCoroutine(LoadingToSameLevelSceneASyncCoroutine());
    }

    IEnumerator LoadingToSameLevelSceneASyncCoroutine()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(currentSceneIndex);

        while (loadLevel.progress < 1)
        {
            yield return new WaitForEndOfFrame();
        }
    }

}
