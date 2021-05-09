using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ObjectCollected : MonoBehaviour
{

    public AudioSource clip;
    //Si entre en collision avec le joueur alors :
    //-joue le son de la piece
    //-désactive l'image de la piece
    //-active l'animation de collecte 
    //-détruit la piece
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            clip.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            Destroy(gameObject, 0.8f);
        }
    }
}
