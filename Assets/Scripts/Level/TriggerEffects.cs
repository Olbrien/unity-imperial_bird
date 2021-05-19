using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffects : MonoBehaviour
{
    public Player player;

    public bool speedEight;
    public bool speedTen;
    public bool speedTwelve;
    public bool speedFourteen;
    public bool endingTrigger;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (speedEight)
            {
                player.speedRight = 8;
            }

            else if (speedTen)
            {
                player.speedRight = 10;
            }

            else if (speedTwelve)
            {
                player.speedRight = 12;
            }      
            
            else if (speedFourteen)
            {
                player.speedRight = 14f;
            }
        }
    }
}
