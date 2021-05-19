using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStuff : MonoBehaviour
{
    public Transform backgroundGameObjectTransform;
    public RectTransform backgroundGameObjectRectTransform;

    public Transform particlesMidTransform;

    public bool changeToLevelAppearence;
    public bool changeToMenuAppearence;

    public bool comingFromLevel;

    float speed = 16;
    float step;
    float stepTwo;
    float stepThree;


    Vector3 backgroundGameObjectInitialTransform = new Vector3(0, 0, 0); 
    Vector3 backgroundGameObjectTopUpTransform = new Vector3(0, 9, 0);

    Vector3 backgroundGameObjectInitialSize = new Vector3(1, 1, 1);
    Vector3 backgroundGameObjectTopUpSize = new Vector3(1, 0.8f, 1);

    Vector3 particlesMidGameObjectInitialSize = new Vector3(0.3f, 0.3f, 0.3f);
    Vector3 particlesMidGameObjectTopUpSize = new Vector3(0.3f, 0.24f, 0.3f);





    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }



    void Update()
    {
        if (changeToLevelAppearence)
        {
            ChangeToLevel();
        }

        else if (changeToMenuAppearence)
        {
            ChangeToMenu();
        }
    }

    void ChangeToLevel()
    {
        step = speed * Time.deltaTime;
        stepTwo = 0.2f * Time.deltaTime;
        stepThree = 0.07f * Time.deltaTime;

        backgroundGameObjectTransform.localPosition = Vector3.MoveTowards(backgroundGameObjectTransform.localPosition, backgroundGameObjectTopUpTransform, step);
        backgroundGameObjectRectTransform.localScale = Vector3.MoveTowards(backgroundGameObjectRectTransform.localScale, backgroundGameObjectTopUpSize, stepTwo);

        particlesMidTransform.localScale = Vector3.MoveTowards(particlesMidTransform.localScale, particlesMidGameObjectTopUpSize, stepThree);

        if (backgroundGameObjectTransform.localPosition.y == 9f && backgroundGameObjectRectTransform.localScale.y == 0.8f &&
            particlesMidTransform.localScale.y == 0.24f)
        {
            changeToLevelAppearence = false;
        }
    }


    void ChangeToMenu()
    {
        step = speed * Time.deltaTime;
        stepTwo = 0.2f * Time.deltaTime;
        stepThree = 0.07f * Time.deltaTime;

        backgroundGameObjectTransform.localPosition = Vector3.MoveTowards(backgroundGameObjectTransform.localPosition, backgroundGameObjectInitialTransform, step);
        backgroundGameObjectRectTransform.localScale = Vector3.MoveTowards(backgroundGameObjectRectTransform.localScale, backgroundGameObjectInitialSize, stepTwo);

        particlesMidTransform.localScale = Vector3.MoveTowards(particlesMidTransform.localScale, particlesMidGameObjectInitialSize, stepThree);

        if (backgroundGameObjectTransform.localPosition.y == 0f && backgroundGameObjectRectTransform.localScale.y == 1f &&
            particlesMidTransform.localScale.y == 0.3f)
        {
            changeToMenuAppearence = false;
        }
    }


}
