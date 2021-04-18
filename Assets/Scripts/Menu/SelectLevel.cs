using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public Button Level02Button, Level03Button;
    int levelPassed;
    void Start()
    {
        levelPassed = PlayerPrefs.GetInt("Level Passed");
        Level02Button.interactable = false;
        Level03Button.interactable = false;

        switch (levelPassed) {
            case 1:
                Level02Button.interactable = true;
                break;
            case 2:
                Level02Button.interactable = true;
                Level03Button.interactable = true;
                break;
        }
    }
    public void LeveltoLoad(int level) {
        SceneManager.LoadScene(level);  
    }

    public void resetPlayerPrefs() {
        Level02Button.interactable = false;
        Level03Button.interactable = false;
        PlayerPrefs.DeleteAll();
    }
            

    
}
