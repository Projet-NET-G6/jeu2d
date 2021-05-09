using UnityEngine;
using UnityEngine.SceneManagement;




public class GameOverManagement : MonoBehaviour
{

    public GameObject gameOverUI;
    private bool GameOverMenuActivated = false;
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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && GameOverMenuActivated == false)
        {
            gameOverUI.SetActive(true);
            GameOverMenuActivated = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && GameOverMenuActivated == true)
        {
            gameOverUI.SetActive(false);
            GameOverMenuActivated = false;
        }
        
    }
    //active le menu game over si le joueur meurt voir PlayerHealth.cs
    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }

    //Reload la Scene en cours
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(false);
    }

    //revois le joueur au menu de sélection des mondes 
    public void MainMenuButton()
    {
        SceneManager.LoadScene("SelectWorld");
    }

    //RageQuit du joueur hehe
    public void QuitButton()
    {
        Application.Quit();
    }
}
