using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    int worldPassed,nextScene;
    
    void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex +1;
    }
    private void Update()
    {
        AllObjectsCollected();
    }
    public void AllObjectsCollected()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (transform.childCount==0)
        {
            if(scene.name == "Monde1Level3" || scene.name == "Monde2Level3")
            {
                PlayerPrefs.SetInt("worldPassed", (PlayerPrefs.GetInt("worldPassed") + 1));
                SceneManager.LoadScene("SelectWorld");
            }
            else if(scene.name == "Monde3Level3")
            {
                SceneManager.LoadScene("SelectWorld");
            }
            else
            {
                Debug.Log("Victoire");
                if( scene.name == "Monde1Level1" || scene.name == "Monde1Level2")
                {
                    PlayerPrefs.SetInt("levelPassedMonde1", PlayerPrefs.GetInt("levelPassedMonde1")+1);
                }
                else if (scene.name == "Monde2Level1" || scene.name == "Monde2Level2")
                {
                    PlayerPrefs.SetInt("levelPassedMonde2", PlayerPrefs.GetInt("levelPassedMonde2") + 1);
                }
                else if (scene.name == "Monde3Level1" || scene.name == "Monde3Level2")
                {
                    PlayerPrefs.SetInt("levelPassedMonde3", PlayerPrefs.GetInt("levelPassedMonde3") + 1);
                }
                SceneManager.LoadScene(nextScene);
            }
            
        }
        
    }
}