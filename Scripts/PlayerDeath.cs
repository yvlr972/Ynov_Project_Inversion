using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject gameOverUI; // Panneau d'écran de fin de partie
    public KeyCode restartKey = KeyCode.R; // Touche pour redémarrer la partie

    private bool isDead = false; // Indique si le joueur est mort

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur entre en collision avec un objet portant le tag "Obstacle"
        if (other.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true; // Le joueur est mort
        Time.timeScale = 0f; // Mettre le temps à zéro pour arrêter le jeu

        // Activer le panneau d'écran de fin de partie
        gameOverUI.SetActive(true);
    }

    private void Update()
    {
        // Redémarrer la partie lorsque la touche spécifiée est enfoncée et que le joueur est mort
        if (isDead && Input.GetKeyDown(restartKey))
        {
            Restart();
        }
    }

    public void Restart()
    {
        // Recharger la scène actuelle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Rétablir le temps à la normale
    }
}
