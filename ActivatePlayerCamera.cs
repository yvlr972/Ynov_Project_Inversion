using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCameraController : MonoBehaviour
{
    public Camera gameCamera;

    private void Start()
    {
        if (gameCamera != null)
        {
            gameCamera.enabled = true;
        }
    }
}
