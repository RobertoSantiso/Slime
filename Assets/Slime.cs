using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] Sprite[] frameArrayMI;
    [SerializeField] Sprite[] frameArrayMD;
    [SerializeField] Sprite[] frameArrayMF;
    [SerializeField] Sprite[] frameArrayMA;
    Rigidbody2D rb;
    public float velocidad;
    public float velocidadDiagonal;
    bool moviendose;
    bool miraIz;
    bool miraDer;
    bool miraFrente;
    List<bool> movimientosAnteriores;
    List<bool> movimientosActuales;
    float timer;
    float framerate = .2f;
    int currentFrame;
    
    SpriteRenderer thisSprite;
    Sprite[] sprites;
    Sprite LadoIz;
    Sprite LadoDer;
    Sprite LadoMI1;
    Sprite LadoMI2;
    Sprite LadoMD1;
    Sprite LadoMD2;
    Sprite LadoF;
    Sprite LadoF2;
    Sprite LadoAtras;
    Sprite LadoMA1;
    Sprite LadoMA2;
    Animator animador;
    void Awake()
    {
        LadoIz = Resources.Load<Sprite>("slimeI");
        LadoDer = Resources.Load<Sprite>("slimeD");
        LadoMI1 = Resources.Load<Sprite>("slimeIM1");
        LadoMI2 = Resources.Load<Sprite>("slimeIM2");
        LadoMD1 = Resources.Load<Sprite>("slimeDM1");
        LadoMD2 = Resources.Load<Sprite>("slimeDM2");
        LadoF = Resources.Load<Sprite>("slimeF");
        LadoF2 = Resources.Load<Sprite>("slimeF2");
        LadoAtras = Resources.Load<Sprite>("slimeA");
        LadoMA1 = Resources.Load<Sprite>("slimeAM1");
        LadoMA2 = Resources.Load<Sprite>("slimeAM2");
        animador = GetComponent<Animator>();
        frameArrayMI = new Sprite[] { LadoMI1, LadoMI2 };
        frameArrayMD = new Sprite[] { LadoMD1, LadoMD2 };
        frameArrayMF = new Sprite[] { LadoF, LadoF2 };
        frameArrayMA = new Sprite[] { LadoMA1, LadoMA2 };
        movimientosAnteriores = new List<bool>();
        movimientosActuales = new List<bool>();
        thisSprite = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        velocidad = 70;
        velocidadDiagonal = velocidad* 0.7f;
        moviendose = false;
        miraFrente = true;
    }

    void Animacion()
    {
        
        var frameArray = frameArrayMD;

        if (miraIz || miraDer)
        {
            frameArray = miraIz ? frameArrayMI : frameArrayMD;
        }
        else
        {
            frameArray = miraFrente ? frameArrayMF : frameArrayMA;
        }
        timer += Time.deltaTime;
        if (timer >= framerate)
        {
            timer -= framerate;
            currentFrame = (currentFrame + 1) % frameArray.Length;
            thisSprite.sprite = frameArray[currentFrame];
        }
    }
    void Update()
    {
        moviendose = false;
        if (Input.anyKey)
        {
            moviendose = true;
            miraIz = false;
            miraDer = false;
            miraFrente = false;
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-velocidad, 0)*Time.deltaTime;
            miraIz = true;
            animador.SetBool("SlimeMI", true);
        }
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(velocidad, -0)*Time.deltaTime;
            miraDer = true;
            animador.SetBool("SlimeMD", true);
        }
        if (Input.GetKey("w"))
        {
            rb.velocity = new Vector2(0, velocidad) *Time.deltaTime;
            animador.SetBool("SlimeMA", true);
        }
        if (Input.GetKey("s"))
        {
            rb.velocity = new Vector2(0, -velocidad) *Time.deltaTime;
            miraFrente = true;
            animador.SetBool("SlimeMF", true);
        }
        if (Input.GetKey("a") && Input.GetKey("w"))
        {
            rb.velocity = new Vector2(-velocidadDiagonal, velocidadDiagonal) * Time.deltaTime;
            miraIz = true;
        }
        if (Input.GetKey("d") && Input.GetKey("w"))
        {
            rb.velocity = new Vector2(velocidadDiagonal, velocidadDiagonal) * Time.deltaTime;
            miraDer = true;
        }
        if (Input.GetKey("a") && Input.GetKey("s"))
        {
            rb.velocity = new Vector2(-velocidadDiagonal, -velocidadDiagonal) * Time.deltaTime;
            miraIz = true;
        }
        if (Input.GetKey("d") && Input.GetKey("s"))
        {
            rb.velocity = new Vector2(velocidadDiagonal, -velocidadDiagonal) * Time.deltaTime;
            miraDer = true;
        }
        if (moviendose == false)
        {
            rb.velocity = new Vector2(0, 0);
            animador.SetBool("SlimeMI", false);
            animador.SetBool("SlimeMD", false);
            animador.SetBool("SlimeMA", false);
            animador.SetBool("SlimeMF", false);

            //if (miraIz == true)
            //    thisSprite.sprite = LadoIz;
            //else if (miraDer == true)
            //    thisSprite.sprite = LadoDer;
            //else if (miraFrente == true)
            //    thisSprite.sprite = LadoF;
            //else
            //    thisSprite.sprite = LadoAtras;
        }
        //else
        //{
        //    Animacion();
        //}
        print(animador.GetBool("isAnimating"));
    }
}
