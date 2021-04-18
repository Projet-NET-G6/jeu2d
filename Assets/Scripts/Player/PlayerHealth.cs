using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(100);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
            return;
        }
    }

    public void Die()
    {
        Debug.Log("Le joueur est éliminé");
        PlayerMovements.instance.enabled = false;
        PlayerMovements.instance.animator.SetTrigger("Despawn");
        PlayerMovements.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovements.instance.playerCollider.enabled = false;
        GameOverManagement.instance.OnPlayerDeath();
    }
}
