using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public void GoToMenu()
    {
        // Charger la scène du menu principal
        SceneManager.LoadScene("ProceduralLevel");
    }
}
