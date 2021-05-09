using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ActivationTrampoline : MonoBehaviour
{
    public float boostJump;
    public Animator animator;

    public AudioSource clip;
    //Si entre en collision avec le jour alors active l'animation de trampo + le son et donne Player vitesse Y pour le faire sauter
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * boostJump);
            animator.Play("ActivatedTrampoline");

            clip.Play();
        }
    }
}