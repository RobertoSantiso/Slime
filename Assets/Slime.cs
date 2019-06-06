using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocidad;
    public float velocidadDiagonal;
    bool moviendose;
    float timer;
    float framerate = .2f;
    int currentFrame;
    SpriteRenderer thisSprite;
    Animator animador;
    void Awake()
    {
        animador = GetComponent<Animator>();
        thisSprite = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        velocidad = 70;
        velocidadDiagonal = velocidad* 0.7f;
        moviendose = false;
    }

    void Update()
    {
        moviendose = false;
        animador.SetBool("SlimeMI", false);
        animador.SetBool("SlimeMD", false);
        animador.SetBool("SlimeMA", false);
        animador.SetBool("SlimeMF", false);
        animador.SetBool("SlimeMIA", false);
        animador.SetBool("SlimeMIF", false);
        animador.SetBool("SlimeMDA", false);
        animador.SetBool("SlimeMDF", false);
        animador.SetBool("SlimeIdle", true);
        if (Input.anyKey)
        {
            moviendose = true;
            animador.SetBool("SlimeIdle", false);
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-velocidad, 0)*Time.deltaTime;
            animador.SetBool("SlimeMI", true);
            thisSprite.flipX = true;
        }
        else
            thisSprite.flipX = false;
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(velocidad, -0)*Time.deltaTime;
            animador.SetBool("SlimeMD", true);
        }
        if (Input.GetKey("w"))
        {
            rb.velocity = new Vector2(0, velocidad) *Time.deltaTime;
            animador.SetBool("SlimeMA", true);
        }
        if (Input.GetKey("s"))
        {
            rb.velocity = new Vector2(0, -velocidad) * Time.deltaTime;
            animador.SetBool("SlimeMF", true);
        }
        if (Input.GetKey("a") && Input.GetKey("w"))
        {
            rb.velocity = new Vector2(-velocidadDiagonal, velocidadDiagonal) * Time.deltaTime;
            animador.SetBool("SlimeMIA", true);
        }
        if (Input.GetKey("d") && Input.GetKey("w"))
        {
            rb.velocity = new Vector2(velocidadDiagonal, velocidadDiagonal) * Time.deltaTime;
            animador.SetBool("SlimeMDA", true);
        }
        if (Input.GetKey("a") && Input.GetKey("s"))
        {
            rb.velocity = new Vector2(-velocidadDiagonal, -velocidadDiagonal) * Time.deltaTime;
            animador.SetBool("SlimeMIF", true);
        }
        if (Input.GetKey("d") && Input.GetKey("s"))
        {
            rb.velocity = new Vector2(velocidadDiagonal, -velocidadDiagonal) * Time.deltaTime;
            animador.SetBool("SlimeMDF", true);
        }
        if (moviendose == false)
        {
            rb.velocity = new Vector2(0, 0);            
            animador.SetBool("SlimeIdle", true);
        }
    }
}
