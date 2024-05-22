using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject gameOverUI; // Canvas d'écran de fin de partie
    public KeyCode restartKey = KeyCode.R; // Touche pour redémarrer la partie

    private bool isDead = false; // Indique si le joueur est mort

    public void Die()
    {
        if (!isDead)
        {
            isDead = true; // Le joueur est mort
            Time.timeScale = 0f; // Mettre le temps à zéro pour arrêter le jeu

            // Activer le canvas d'écran de fin de partie
            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true);
            }
        }
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Rétablir le temps à la normale
        isDead = false; // Réinitialiser l'état de mort du joueur
    }
}
