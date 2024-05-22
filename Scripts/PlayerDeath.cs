using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject gameOverUI; // Canvas d'�cran de fin de partie
    public KeyCode restartKey = KeyCode.R; // Touche pour red�marrer la partie

    private bool isDead = false; // Indique si le joueur est mort

    public void Die()
    {
        if (!isDead)
        {
            isDead = true; // Le joueur est mort
            Time.timeScale = 0f; // Mettre le temps � z�ro pour arr�ter le jeu

            // Activer le canvas d'�cran de fin de partie
            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true);
            }
        }
    }

    private void Update()
    {
        // Red�marrer la partie lorsque la touche sp�cifi�e est enfonc�e et que le joueur est mort
        if (isDead && Input.GetKeyDown(restartKey))
        {
            Restart();
        }
    }

    public void Restart()
    {
        // Recharger la sc�ne actuelle
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // R�tablir le temps � la normale
        isDead = false; // R�initialiser l'�tat de mort du joueur
    }
}
