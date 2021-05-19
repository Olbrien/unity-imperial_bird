using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Player player;
    public Transform playerTransform;
    public Transform cameraTransform;
    public Transform backgroundTransform;

    public bool followingPlayer;
    float straight;

    public Vector3 offset;

    Vector3 recordPosition;
    int section;

    Vector3 origPos;
    Vector3 origPosTwo;
    Vector3 tempVec;

    bool shakeCamera;
    bool shakeCameraDead;
    float timer;
    float theTime;

    Vector3 desiredPosition;
    Vector3 smoothedPosition;



    void FixedUpdate()
    {
        ShakeCameraUpdate();

        if (followingPlayer && shakeCamera == false)
        {
            desiredPosition = new Vector3(playerTransform.position.x + 4.7f, cameraTransform.position.y, cameraTransform.position.z);
            smoothedPosition = Vector3.Lerp(cameraTransform.position, desiredPosition, 50 * Time.deltaTime);
            transform.position = smoothedPosition;
        }

        else if (followingPlayer && shakeCamera == true)
        {
            desiredPosition = new Vector3(playerTransform.position.x + Random.Range(4.65f, 4.75f), cameraTransform.position.y, cameraTransform.position.z);
            smoothedPosition = Vector3.Lerp(cameraTransform.position, desiredPosition, 50 * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }

    public void UpdateCameraLocation()
    {
        desiredPosition = new Vector3(playerTransform.position.x + 4.7f, cameraTransform.position.y, cameraTransform.position.z);
        smoothedPosition = Vector3.Lerp(cameraTransform.position, desiredPosition, 50 * Time.deltaTime);
        transform.position = smoothedPosition;
    }


    public void ShakeCamera()
    {
        shakeCamera = false;
        backgroundTransform.localPosition = new Vector3(0, 0, -10);
        theTime = 0;
        timer = 0;

        origPos = cameraTransform.position;
        origPos = backgroundTransform.position;
        shakeCamera = true;
    }

    public void ShakeCameraDead()
    {
        shakeCamera = false;        
        backgroundTransform.localPosition = new Vector3(0, 0, -10);
        theTime = 0;
        timer = 0;

        origPos = cameraTransform.position;
        origPos = backgroundTransform.position;
        shakeCameraDead = true;
    }


    void ShakeCameraUpdate()
    {
        if (shakeCamera)
        {
            theTime += Time.deltaTime;

            if (theTime < 0.5f)
            {
                // Create a temporary vector2 with the camera's original position modified by a random distance from the origin.
                tempVec = origPos + Random.insideUnitSphere * 0.2f;                

                // Apply the temporary vector.
                cameraTransform.localPosition = tempVec;
                backgroundTransform.localPosition = tempVec;
            }


            if (theTime >= 0.5f)
            {
                // Return back to the original position.
                cameraTransform.localPosition = origPos;
                backgroundTransform.localPosition = new Vector3(0, 0, -10);

                shakeCamera = false;
                theTime = 0;
                timer = 0;
            }
        }

        else if (shakeCameraDead)
        {
            theTime += Time.deltaTime;

            if (theTime < 0.2f)
            {
                // Create a temporary vector2 with the camera's original position modified by a random distance from the origin.
                tempVec = origPos + Random.insideUnitSphere * 0.1f;

                // Apply the temporary vector.
                cameraTransform.localPosition = tempVec;
                backgroundTransform.localPosition = tempVec;
            }


            else if (theTime >= 0.2f)
            {
                // Return back to the original position.
                cameraTransform.localPosition = origPos;
                backgroundTransform.localPosition = new Vector3(0,0,-10);

                shakeCameraDead = false;
                theTime = 0;
                timer = 0;
            }
        }
    }



}
