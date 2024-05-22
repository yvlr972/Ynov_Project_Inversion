using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    public MenuManager menuManager;

    void Start()
    {
        if (menuManager == null)
        {
            menuManager = FindObjectOfType<MenuManager>();
        }
    }

    public void StartGame()
    {
        menuManager.StartGame();
    }
}
