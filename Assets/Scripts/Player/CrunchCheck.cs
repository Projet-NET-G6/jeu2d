using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrunchCheck : MonoBehaviour
{
    public GameObject parent;
    private int damageOnCollision = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si entre collision avec un tag Ennemi dans notre cas les RockHead ou avec les fondtaions alors tue le joueur
        if (collision.transform.CompareTag("Ennemi") || collision.transform.CompareTag("Fondation"))
        {
            
            PlayerHealth playerHealth = parent.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
