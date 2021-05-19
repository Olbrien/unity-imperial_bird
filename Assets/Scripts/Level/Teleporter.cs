using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Player player;
    public CameraScript cameraScript;

    public Transform targetPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.TeleporterSound();
            player.transform.localPosition = targetPosition.position;
            cameraScript.UpdateCameraLocation();
        }
    }

}
