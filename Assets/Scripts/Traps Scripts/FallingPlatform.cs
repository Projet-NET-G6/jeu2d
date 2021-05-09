using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //Si entre en collision avec le joueur alors invoque la methode activation
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Invoke("activation", 0.5f);
        }
    }
    //rend l'objet dynamic afin qu'il tombe puis le détruit apres X temps
    void activation()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, 3f);
    }
}

