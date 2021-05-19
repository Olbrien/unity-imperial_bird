using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Player player;

    public PolygonCollider2D polygonCollider2D;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public int blinkTimes;
    bool blink;
    float theTime;
    int section;

    public bool isEnabled;


    void Update()
    {
        if (blink)
        {
            if (blink && section == 0)
            {
                spriteRenderer.enabled = false;

                section += 1;
            }

            else if (blink && section == 1)
            {
                 theTime += Time.deltaTime;

                 if (theTime >= 0.1f)
                 {
                     spriteRenderer.enabled = true;
                     section += 1;
                     theTime = 0;
                 }
            }

            else if (blink && section == 2)
            {
                theTime += Time.deltaTime;
 
                if (theTime >= 0.1f)
                {
                    spriteRenderer.enabled = false;
                    section += 1;
                    theTime = 0;
                }
            }

            else if (blink && section == 3)
            {
                theTime += Time.deltaTime;

                if (theTime >= 0.1f)
                {
                    polygonCollider2D.enabled = true;
                    spriteRenderer.enabled = true;
                    theTime = 0;
                    blink = false;
                }
            }

        }
    }


    public void TurnOnObject()
    {
        spriteRenderer.enabled = true;
        isEnabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GettingHit();
            polygonCollider2D.enabled = false;
            blink = true;
        }

        if (collision.gameObject.CompareTag("BackTrigger"))
        {
            spriteRenderer.enabled = false;
            isEnabled = false;
        }
    }

    public void FadeOut()
    {
        animator.SetBool(1739810581, true);
    }
}
