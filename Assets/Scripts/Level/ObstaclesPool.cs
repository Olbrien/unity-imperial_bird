using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPool : MonoBehaviour
{
    public List<Wall> walls;
    public List<Coin> coins;
    public List<GameObject> coinsTotalCount;
    public GameObject teleporters;

    public bool hasTeleporters;

    public void FadeOut()
    {
        foreach (var wall in walls)
        {
            wall.FadeOut();
        }

        foreach (var coin in coins)
        {
            coin.FadeOut();
        }

        if (hasTeleporters)
        {
            teleporters.SetActive(false);
        }
    }
}
