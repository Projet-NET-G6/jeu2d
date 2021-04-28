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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Invoke("activation", 0.5f);
        }
    }

    void activation()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, 3f);
    }
}

