using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public Camera camera;

    void Awake()
    {
        if (camera.aspect > 2.1f) // 19:9 
        {
            //Debug.Log("19:9");
            camera.orthographicSize = 3.85f;
        }

        else if (camera.aspect >= 1.9f) // 18:9
        {
            //Debug.Log("18:9");
            camera.orthographicSize = 4;
        }

        else if (camera.aspect >= 1.7f) // 16:9
        {
            //Debug.Log("16:9");
            camera.orthographicSize = 4.5f;
        }

        else if (camera.aspect > 1.6f) // 5:3
        {
            //Debug.Log("5:3");
            camera.orthographicSize = 4.8f;
        }

        else if (camera.aspect == 1.6f) // 16:10
        {
            //Debug.Log("16:10");
            camera.orthographicSize = 5f;
        }

        else if (camera.aspect >= 1.5f) // 3:2
        {
            //Debug.Log("3:2");
            camera.orthographicSize = 5.4f;
        }

        else if (camera.aspect < 1.5f) // 4:3
        {
            //Debug.Log("4:3");
            camera.orthographicSize = 6.1f;
        }
    }
}
