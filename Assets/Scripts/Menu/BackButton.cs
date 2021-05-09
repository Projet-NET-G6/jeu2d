using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    //Load la scene précédente voulue ou (skin shop)
    public void Back(string name)
    {
        SceneManager.LoadScene(name);
    }
}
