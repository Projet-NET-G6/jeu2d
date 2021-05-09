using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    int worldPassed,nextScene;

    public GameObject transi;

    void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex +1;
    }
    //Va vérif en permance si tous les objets ont été détruit ou pas 
    
    private void Update()
    {
        AllObjectsCollected();
    }

    public void AllObjectsCollected()
    {
        Scene scene = SceneManager.GetActiveScene();
        //Si plus aucun objet(enfant) alors passe au niv suivant / scene de selection des mondes
        //active l'animation de transi
        if (transform.childCount==0)
        {
            transi.SetActive(true);
            if(scene.name == "Monde1Level3" && PlayerPrefs.GetInt("worldPassed") == 0)
            {
                PlayerPrefs.SetInt("worldPassed", (PlayerPrefs.GetInt("worldPassed") + 1));
                SceneManager.LoadScene("SelectWorld");
            }
            else if(scene.name == "Monde2Level3" && PlayerPrefs.GetInt("worldPassed") == 1)
            {
                PlayerPrefs.SetInt("worldPassed", (PlayerPrefs.GetInt("worldPassed") + 1));
                SceneManager.LoadScene("SelectWorld");
            }
            else if(scene.name == "Monde1Level3" || scene.name == "Monde2Level3" || scene.name == "Monde3Level3")
            {
                SceneManager.LoadScene("SelectWorld");
            }
            else
            {
                //Debug.Log("Victoire");
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