using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public ObstaclesPool obstaclesPool;
    public SpriteRenderer spriteRenderer;

    public bool isCoin;
    public bool isWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FrontTrigger"))
        {
            if (isCoin)
            {
                foreach (var coin in obstaclesPool.coins)
                {
                    if (coin.isEnabled == false)
                    {
                        coin.TurnOnObject();
                        coin.transform.position = transform.position;
                        coin.transform.localScale = transform.localScale;
                        return;
                    }
                }
            }

            if (isWall)
            {
                foreach (var wall in obstaclesPool.walls)
                {
                    if (wall.isEnabled == false)
                    {
                        wall.TurnOnObject();
                        wall.transform.position = transform.position;
                        wall.transform.rotation = transform.rotation;
                        wall.transform.localScale = transform.localScale;
                        wall.spriteRenderer.color = spriteRenderer.color;
                        wall.spriteRenderer.flipX = spriteRenderer.flipX;
                        wall.spriteRenderer.flipY = spriteRenderer.flipY;
                        return;
                    }
                }
            }
        }
    }
}
