using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public static PlayerHealth instance;
    public Animator animator;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }
    //initialise les hps du joueur à 100 
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
       
    }

    
    void Update()
    {
        //afin de test le menu GameOver
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(100);
        }
    }
    // le joueur prend X degat quand cette methode est appelée 
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //si hp du player en dessous ou egale a 0 alors appele Die();
        if (currentHealth <= 0)
        {
            Die();
            return;
        }
    }

    //cette methode fait :
    //désactive l'image du joueur;
    //active son animation de mort
    //rend sa physique en Kinematic
    //désactive son collider
    //appel la methode OnPlayerDeath (voir GameOverManagement.cs)
    public void Die()
    {
        Debug.Log("Le joueur est éliminé");
        NewPlayerMovements.instance.enabled = false;
        NewPlayerMovements.instance.animator.SetTrigger("IsDead");
        NewPlayerMovements.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        NewPlayerMovements.instance.playerCollider.enabled = false;
        GameOverManagement.instance.OnPlayerDeath();
        
    }
}
