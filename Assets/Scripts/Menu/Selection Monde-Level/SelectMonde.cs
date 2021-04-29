using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMonde : MonoBehaviour
{
    public Button Monde02Button, Monde03Button;
    int worldPassed,test;
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        worldPassed = PlayerPrefs.GetInt("worldPassed");
        Debug.Log(worldPassed);
        Monde02Button.interactable = false;
        Monde03Button.interactable = false;

        
    }
    void Update()
    {
        worldPassed = PlayerPrefs.GetInt("worldPassed");
        Debug.Log(worldPassed);
        switch (worldPassed)
        {
            case 1:
                Monde02Button.interactable = true;
                break;
            case 2:
                Monde02Button.interactable = true;
                Monde03Button.interactable = true;
                break;
        }
    }
    public void LeveltoLoad(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void resetPlayerPrefs() {
        Monde02Button.interactable = false;
        Monde03Button.interactable = false;
        PlayerPrefs.DeleteAll();
    }
            

    
}
