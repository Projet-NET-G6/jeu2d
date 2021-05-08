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
    
    //Si animation de feu acitf alors tuera le personnage
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("IsActivated", false);
    }
}
