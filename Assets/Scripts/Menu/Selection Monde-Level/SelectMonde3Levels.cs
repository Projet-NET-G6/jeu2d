using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMonde3Levels : MonoBehaviour
{
    public Button Level02Button, Level03Button;
    int levelPassed, test;


    void Start()
    {
        //PlayerPrefs.DeleteAll();
        levelPassed = PlayerPrefs.GetInt("levelPassedMonde3");
        //Debug.Log(levelPassed);
        Level02Button.interactable = false;
        Level03Button.interactable = false;


    }
    void Update()
    {
        switch (levelPassed)
        {
            case 1:
                Level02Button.interactable = true;
                break;
            case 2:
                Level02Button.interactable = true;
                Level03Button.interactable = true;
                break;
        }
    }
    public void LeveltoLoad(string name)
    {
        SceneManager.LoadScene(name);
    }
}
