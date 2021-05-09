using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsWindow;

    //Envoie le joueur a SelectWord
    public void StartGame()
    {
        SceneManager.LoadScene("SelectWorld");
    }
    //active le menu Options
    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }
    //ferme le menu Options
    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
    //quitte le jeu
    public void QuitGame()
    {
        Application.Quit();
    }


}
