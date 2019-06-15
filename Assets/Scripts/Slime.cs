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
    void ControlMovimiento()
    {
        MovimientoTenso();
        if (!moviendose)
        {
            MovimientoDiagonal();
            if (Input.GetKey("a"))
                thisSprite.flipX = true;
            else
                thisSprite.flipX = false;
        }
            
        
        if (moviendose==false)
            MovimientoCruz();
    }
    void MovimientoCruz()
    {
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-velocidad, 0) * Time.deltaTime;
            animador.SetBool("SlimeMI", true);
            moviendose = true;
        }
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(velocidad, -0) * Time.deltaTime;
            animador.SetBool("SlimeMD", true);
            moviendose = true;
        }
        if (Input.GetKey("w"))
        {
            rb.velocity = new Vector2(0, velocidad) * Time.deltaTime;
            animador.SetBool("SlimeMA", true);
            moviendose = true;
        }
        if (Input.GetKey("s"))
        {
            rb.velocity = new Vector2(0, -velocidad) * Time.deltaTime;
            animador.SetBool("SlimeMF", true);
            moviendose = true;
        }
    }
    void MovimientoDiagonal()
    {
        if (Input.GetKey("a") && Input.GetKey("w"))
        {
            rb.velocity = new Vector2(-velocidadDiagonal, velocidadDiagonal) * Time.deltaTime;
            animador.SetBool("SlimeMIA", true);
            moviendose = true;
        }
        if (Input.GetKey("d") && Input.GetKey("w"))
        {
            rb.velocity = new Vector2(velocidadDiagonal, velocidadDiagonal) * Time.deltaTime;
            animador.SetBool("SlimeMDA", true);
            moviendose = true;
        }
        if (Input.GetKey("a") && Input.GetKey("s"))
        {
            rb.velocity = new Vector2(-velocidadDiagonal, -velocidadDiagonal) * Time.deltaTime;
            animador.SetBool("SlimeMIF", true);
            moviendose = true;
        }
        if (Input.GetKey("d") && Input.GetKey("s"))
        {
            rb.velocity = new Vector2(velocidadDiagonal, -velocidadDiagonal) * Time.deltaTime;
            animador.SetBool("SlimeMDF", true);
            moviendose = true;
        }
    }
    /// <summary>
    /// se aplica cuando se pulsan teclas fuera de lo esperado
    /// </summary>
    void MovimientoTenso()
    {
        if (Input.GetKey("a") && Input.GetKey("d"))
        {
            rb.velocity = new Vector2(0, 0) * Time.deltaTime;
            animador.SetBool("SlimeTenso", true);
            moviendose = true;
        }
        if (Input.GetKey("w") && Input.GetKey("s"))
        {
            rb.velocity = new Vector2(0, 0) * Time.deltaTime;
            animador.SetBool("SlimeTenso", true);
            moviendose = true;
        }
    }
    void Update()
    {
        moviendose = false;
        if (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("w") || Input.GetKey("s"))
        {
            animador.SetBool("SlimeMI", false);
            animador.SetBool("SlimeMD", false);
            animador.SetBool("SlimeMA", false);
            animador.SetBool("SlimeMF", false);
            animador.SetBool("SlimeMIA", false);
            animador.SetBool("SlimeMDA", false);
            animador.SetBool("SlimeMIF", false);
            animador.SetBool("SlimeMDF", false);
            animador.SetBool("SlimeTenso", false);
            animador.SetBool("SlimeIdle", false);
            animador.SetBool("SlimeMoviendose", true);
            ControlMovimiento();
            
        }
        else {
            animador.SetBool("SlimeMoviendose", false);
            rb.velocity = new Vector2(0, 0);            
            animador.SetBool("SlimeIdle", true);
        }
    }
}
