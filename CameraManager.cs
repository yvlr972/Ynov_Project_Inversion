using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Camera menuCamera;
    public Camera gameCamera;
    public string gameSceneName;

    private void Start()
    {
        if (menuCamera != null) menuCamera.enabled = true;
        if (gameCamera != null) gameCamera.enabled = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
        if (menuCamera != null) menuCamera.enabled = false;
        if (gameCamera != null) gameCamera.enabled = true;
    }
}
