using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMonde : MonoBehaviour
{

    public Button Monde02Button, Monde03Button;
    int worldPassed,test;
    
    //Remet à zero tous les boutons 
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        worldPassed = PlayerPrefs.GetInt("worldPassed");
        //Debug.Log(worldPassed);
        Monde02Button.interactable = false;
        Monde03Button.interactable = false; 
    }

    //Met à jour les boutons juste apres si les mondes sont passés 
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

    //load la scene voulu
    public void LeveltoLoad(string name)
    {
        SceneManager.LoadScene(name);
    }
    
}
