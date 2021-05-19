using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOfGame : MonoBehaviour
{

    PlayerController playerController;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>();

        playerController.LoadingToMenuSceneAsync();
    }

}
