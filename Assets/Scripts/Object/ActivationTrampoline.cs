using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationTrampoline : MonoBehaviour
{
    public float boostJump;

    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * boostJump);
            animator.Play("ActivatedTrampoline");

        }
    }
}