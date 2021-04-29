using UnityEngine;
using UnityEngine.SceneManagement;




public class GameOverManagement : MonoBehaviour
{

    public GameObject gameOverUI;

    public static GameOverManagement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }

    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("SelectWorld");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
