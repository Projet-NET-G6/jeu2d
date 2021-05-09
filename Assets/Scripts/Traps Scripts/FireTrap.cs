using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private int damageOnCollision = 100;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    //si entre en collision avec quelque chose alors active ses animations
    //si animation de feu en cours alors infligera des dégats au joueurs
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("IsActivated", true);
        
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("FireOn"))
        {
            Debug.Log("Hello");
            if (collision.CompareTag("Player"))
            {
                PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(damageOnCollision);
            }
        }
    }
    //désactive l'animation de feu 
    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("IsActivated", false);
    }
}
