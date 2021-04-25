using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    private void Update()
    {
        AllObjectsCollected();
    }
    public void AllObjectsCollected()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (transform.childCount==0)
        {
            if(scene.name == "Monde1Level3" || scene.name == "Monde2Level3" || scene.name == "Monde3Level3")
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                Debug.Log("Victoire");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            
        }
        
    }
}