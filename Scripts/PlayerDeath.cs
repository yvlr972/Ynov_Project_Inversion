using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject gameOverUI; // Panneau d'�cran de fin de partie
    public KeyCode restartKey = KeyCode.R; // Touche pour red�marrer la partie

    private bool isDead = false; // Indique si le joueur est mort

    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si le joueur entre en collision avec un objet portant le tag "Obstacle"
        if (other.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true; // Le joueur est mort
        Time.timeScale = 0f; // Mettre le temps � z�ro pour arr�ter le jeu

        // Activer le panneau d'�cran de fin de partie
        gameOverUI.SetActive(true);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // R�tablir le temps � la normale
    }
}
