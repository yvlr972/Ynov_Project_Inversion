using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject player;  // Assurez-vous de d�sactiver les contr�les du joueur quand le menu est actif

    void Start()
    {
        // Afficher le menu et d�sactiver le joueur au d�marrage
        ShowMenu();
    }

    public void ShowMenu()
    {
        menuCanvas.SetActive(true);
        player.SetActive(false);  // D�sactivez le joueur ou son contr�le
        Time.timeScale = 0;  // Arr�tez le temps de jeu
    }

    public void StartGame()
    {
        menuCanvas.SetActive(false);
        player.SetActive(true);  // R�activez le joueur ou son contr�le
        Time.timeScale = 1;  // Reprenez le temps de jeu
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
