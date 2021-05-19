using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int health;
    public float speedRight = 11;
    Vector3 movement;
    float moveVertical;
    public float force;
    Vector3 moveRight;

    public bool startMovingUpAndDown;
    public bool startMovingRight;
    public bool onMenu;

    public PlayerControllerCollector playerControllerCollector;
    public TextMeshProUGUI totalDeathsTxt;

    public ParticleSystem trailParticleSystem;

    public ParticleSystem hitParticleSystemOne;
    public ParticleSystem hitParticleSystemTwo;
    public ParticleSystem hitParticleSystemThree;

    public ObstaclesPool obstaclesPool;

    public SpriteRenderer spriteRenderer;

    public LevelMenu levelMenu;

    public Rigidbody2D rigidBody2D;
    public CameraScript cameraSript;

    Vector3 moveRig;

    public Transform heartOneTransform;
    public Transform heartTwoTransform;
    public Transform heartThreeTransform;
    public Transform heartFourTransform;
    public Transform heartFiveTransform;
    public Transform heartSixTransform;

    public Canvas heartFourCanvas;
    public Canvas heartFiveCanvas;
    public Canvas heartSixCanvas;

    public Image redHeartOne;
    public Image redHeartTwo;
    public Image redHeartThree;

    public Image redHeartFour;
    public Image redHeartFive;
    public Image redHeartSix;

    public Animator blackHeartOneAnimator;
    public Animator blackHeartTwoAnimator;
    public Animator blackHeartThreeAnimator;

    public Animator blackHeartFourAnimator;
    public Animator blackHeartFiveAnimator;
    public Animator blackHeartSixAnimator;

    public RectTransform blackHeartOneRectTransform;
    public RectTransform blackHeartTwoRectTransform;
    public RectTransform blackHeartThreeRectTransform;

    public RectTransform blackHeartFourRectTransform;
    public RectTransform blackHeartFiveRectTransform;
    public RectTransform blackHeartSixRectTransform;

    public BoxCollider2D boxCollider2D;

    public Image greenBar;
    public GameObject endingTrigger;
    float distance;
    bool startGreenBar = true;
    bool start = true;


    Vector3 desiredPosition;
    Vector3 smoothedPosition;
    float moveRightFloat;

    public bool isDead;

    void FixedUpdate()
    {
        if (start)
        {
            if (!playerControllerCollector.healthFour && !playerControllerCollector.healthFive && !playerControllerCollector.healthSix)
            {
                health = 3;
            }

            else if (playerControllerCollector.healthFour && !playerControllerCollector.healthFive && !playerControllerCollector.healthSix)
            {
                health = 4;
                heartOneTransform.localPosition = new Vector3(-66, 0, 0);
                heartTwoTransform.localPosition = new Vector3(-21, 0, 0);
                heartThreeTransform.localPosition = new Vector3(24, 0, 0);
                heartFourTransform.localPosition = new Vector3(69, 0, 0);
                heartFourCanvas.enabled = true;
            }

            else if (playerControllerCollector.healthFour && playerControllerCollector.healthFive && !playerControllerCollector.healthSix)
            {
                health = 5;
                heartOneTransform.localPosition = new Vector3(-87, 0, 0);
                heartTwoTransform.localPosition = new Vector3(-42, 0, 0);
                heartThreeTransform.localPosition = new Vector3(3, 0, 0);
                heartFourTransform.localPosition = new Vector3(48, 0, 0);
                heartFiveTransform.localPosition = new Vector3(93, 0, 0);
                heartFourCanvas.enabled = true;
                heartFiveCanvas.enabled = true;
            }

            else if (playerControllerCollector.healthFour && playerControllerCollector.healthFive && playerControllerCollector.healthSix)
            {
                health = 6;
                heartOneTransform.localPosition = new Vector3(-108, 0, 0);
                heartTwoTransform.localPosition = new Vector3(-63, 0, 0);
                heartThreeTransform.localPosition = new Vector3(-18, 0, 0);
                heartFourTransform.localPosition = new Vector3(27, 0, 0);
                heartFiveTransform.localPosition = new Vector3(72, 0, 0);
                heartSixTransform.localPosition = new Vector3(117, 0, 0);
                heartFourCanvas.enabled = true;
                heartFiveCanvas.enabled = true;
                heartSixCanvas.enabled = true;
            }

            start = false;
        }

        if (startGreenBar)
        {
            if (transform.localPosition.x / endingTrigger.transform.position.x < 1)
            {
                distance = transform.localPosition.x / endingTrigger.transform.position.x;

                greenBar.fillAmount = distance;
            }

            else if (transform.localPosition.x / endingTrigger.transform.position.x >= 1)
            {
                greenBar.fillAmount = 1;

                if (levelMenu.coinsCollected >= levelMenu.coinsTotal)
                {
                    levelMenu.YouMadeIt();
                }

                else if (levelMenu.coinsCollected < levelMenu.coinsTotal)
                {
                    levelMenu.YouMadeItButNoCoins();
                }
                startGreenBar = false;
            }
        }


        if (startMovingRight)
        {            
            transform.Translate(Vector3.right * speedRight * Time.fixedDeltaTime);
        }

        //if (startMovingRight)
        //{
        //    cameraSript.followingPlayer = true;
        //    moveRightFloat += 1 * speedRight * Time.fixedDeltaTime;
        //    desiredPosition = new Vector3(moveRightFloat, transform.position.y, transform.position.z);
        //    transform.position = Vector3.Lerp(transform.position, desiredPosition, 50 * Time.deltaTime);
        //}


        if (startMovingUpAndDown && onMenu == false)
        {
            movement = new Vector3(0f, moveVertical, 0f);
            rigidBody2D.AddForce(movement * force);         
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            startMovingUpAndDown = false;
            OnReleasingMoveUpButton();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            startMovingUpAndDown = false;
            OnHoldingMoveUpButton();
        }


        if (Input.GetKeyUp(KeyCode.S))
        {
            startMovingUpAndDown = false;
            OnReleasingMoveDownButton();
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            startMovingUpAndDown = false;
            OnHoldingMoveDownButton();
        }


        if (Input.GetKeyUp(KeyCode.C))
        {
            OnReleasingBoostButton();
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            OnHoldingBoostButton();
        }



    }


    public void OnHoldingMoveUpButton()
    {
        startMovingUpAndDown = true;
        moveVertical = 0.8f;
    }

    public void OnReleasingMoveUpButton()
    {
        startMovingUpAndDown = false;
        moveVertical = 0.8f;
    }

    public void OnHoldingMoveDownButton()
    {
        startMovingUpAndDown = true;
        moveVertical = -0.8f;
    }

    public void OnReleasingMoveDownButton()
    {
        startMovingUpAndDown = false;
        moveVertical = -0.8f;
    }




    public void OnHoldingBoostButton()
    {
        force = 1050;
    }

    public void OnReleasingBoostButton()
    {
        force = 750;
    }




    public void GettingHit()
    {
        health -= 1;

        if (health == 5)
        {
            playerControllerCollector.SoundHit();
            cameraSript.ShakeCamera();
            hitParticleSystemOne.Play();
            redHeartSix.enabled = false;
            blackHeartSixAnimator.enabled = false;
            blackHeartSixRectTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }

        if (health == 4)
        {
            playerControllerCollector.SoundHit();
            cameraSript.ShakeCamera();
            hitParticleSystemOne.Play();
            redHeartFive.enabled = false;
            blackHeartFiveAnimator.enabled = false;
            blackHeartFiveRectTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }

        if (health == 3)
        {
            playerControllerCollector.SoundHit();
            cameraSript.ShakeCamera();
            hitParticleSystemOne.Play();
            redHeartFour.enabled = false;
            blackHeartFourAnimator.enabled = false;
            blackHeartFourRectTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }

        if (health == 2)
        {
            playerControllerCollector.SoundHit();
            cameraSript.ShakeCamera();
            hitParticleSystemOne.Play();
            redHeartThree.enabled = false;
            blackHeartThreeAnimator.enabled = false;
            blackHeartThreeRectTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }

        else if (health == 1)
        {
            playerControllerCollector.SoundHit();
            cameraSript.ShakeCamera();
            hitParticleSystemTwo.Play();
            redHeartTwo.enabled = false;
            blackHeartTwoAnimator.enabled = false;
            blackHeartTwoRectTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }

        else if (health == 0)
        {
            playerControllerCollector.SoundDying();
            playerControllerCollector.StopMusicAndSoundWind();
            isDead = true;

            if (levelMenu.atLevelOne)
            {
                playerControllerCollector.levelOneDeaths += 1;
                playerControllerCollector.SaveGameToMain();

                totalDeathsTxt.text = "<color=#FFF900>Deaths:</color> " + playerControllerCollector.levelOneDeaths.ToString();
            }

            else if (levelMenu.atLevelTwo)
            {
                playerControllerCollector.levelTwoDeaths += 1;
                playerControllerCollector.SaveGameToMain();

                totalDeathsTxt.text = "<color=#FFF900>Deaths:</color> " + playerControllerCollector.levelTwoDeaths.ToString();
            }

            else if (levelMenu.atLevelThree)
            {
                playerControllerCollector.levelThreeDeaths += 1;
                playerControllerCollector.SaveGameToMain();

                totalDeathsTxt.text = "<color=#FFF900>Deaths:</color> " + playerControllerCollector.levelThreeDeaths.ToString();
            }

            obstaclesPool.FadeOut();
            cameraSript.ShakeCameraDead();
            hitParticleSystemThree.Play();
            redHeartOne.enabled = false;
            blackHeartOneAnimator.enabled = false;
            blackHeartOneRectTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);

            startMovingRight = false;
            trailParticleSystem.Stop();            
            spriteRenderer.enabled = false;
            startMovingUpAndDown = false;
            levelMenu.YouDied();
        }
    }



    public void TeleporterSound()
    {
        playerControllerCollector.SoundTeleport();
    }

}

