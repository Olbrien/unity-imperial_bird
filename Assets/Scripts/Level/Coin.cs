using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public LevelMenu levelMenu;
    public Transform player;
        
    public Transform thisGameObjectTransform;
    public SpriteRenderer thisGameObjectRenderer;
    public Animator thisGameObjectAnimator;
    public BoxCollider2D thisGameObjectBoxCollider2D;

    public Animator animator;

    public bool isEnabled;    
    


    public void TurnOnObject()
    {
        thisGameObjectRenderer.enabled = true;
        thisGameObjectAnimator.enabled = true;
        isEnabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelMenu.CoinSound();
            thisGameObjectRenderer.enabled = false;
            thisGameObjectAnimator.enabled = false;
            levelMenu.UpdateCoinsCollected();
            levelMenu.coinsCollected += 1;
        }

        if (collision.gameObject.CompareTag("BackTrigger"))
        {
            isEnabled = false;
            thisGameObjectRenderer.enabled = false;
        }
    }

    public void FadeOut()
    {
        animator.SetBool(1739810581, true);
    }
}
