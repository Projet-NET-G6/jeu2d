using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMonde1Levels : MonoBehaviour
{
    public Button Level02Button, Level03Button;
    int levelPassed, test;

    //Remet à zero tous les boutons 
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        levelPassed = PlayerPrefs.GetInt("levelPassedMonde1");
        //Debug.Log(levelPassed);
        Level02Button.interactable = false;
        Level03Button.interactable = false;
    }

    //Met à jour les boutons juste apres si les mondes sont passés 
    void Update()
    {
        switch (levelPassed)
        {
            case 0:
                break;
            case 1:
                Level02Button.interactable = true;
                break;
            case 2:
                Level02Button.interactable = true;
                Level03Button.interactable = true;
                break;
            default:
                Level02Button.interactable = true;
                Level03Button.interactable = true;
                break;
        }
    }

    //load la scene voulu
    public void LeveltoLoad(string name)
    {
        SceneManager.LoadScene(name);
    }
}
