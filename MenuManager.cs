using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject player;  // Assurez-vous de désactiver les contrôles du joueur quand le menu est actif

    void Start()
    {
        // Afficher le menu et désactiver le joueur au démarrage
        ShowMenu();
    }

    public void ShowMenu()
    {
        menuCanvas.SetActive(true);
        player.SetActive(false);  // Désactivez le joueur ou son contrôle
        Time.timeScale = 0;  // Arrêtez le temps de jeu
    }

    public void StartGame()
    {
        menuCanvas.SetActive(false);
        player.SetActive(true);  // Réactivez le joueur ou son contrôle
        Time.timeScale = 1;  // Reprenez le temps de jeu
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
