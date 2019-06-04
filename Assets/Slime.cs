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
    public int velocidad;
    public int velocidadDiagonal;
    bool moviendose;
    bool miraIz;
    bool miraDer;
    bool miraFrente;
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
    void Awake()
    {
        LadoIz = Resources.Load<Sprite>("slimeLadoIz");
        LadoDer = Resources.Load<Sprite>("slimeLadoDer");
        LadoMI1 = Resources.Load<Sprite>("slimeLadoIM1");
        LadoMI2 = Resources.Load<Sprite>("slimeLadoIM2");
        LadoMD1 = Resources.Load<Sprite>("slimeLadoDM1");
        LadoMD2 = Resources.Load<Sprite>("slimeLadoDM2");
        LadoF = Resources.Load<Sprite>("slime");
        LadoF2 = Resources.Load<Sprite>("slime2");
        LadoAtras = Resources.Load<Sprite>("slimeAtras");
        LadoMA1 = Resources.Load<Sprite>("slimeMA1");
        LadoMA2 = Resources.Load<Sprite>("slimeMA2");
        frameArrayMI = new Sprite[] { LadoMI1, LadoMI2 };
        frameArrayMD = new Sprite[] { LadoMD1, LadoMD2 };
        frameArrayMF = new Sprite[] { LadoF, LadoF2 };
        frameArrayMA = new Sprite[] { LadoMA1, LadoMA2 };
        thisSprite = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        velocidad = 100;
        velocidadDiagonal = 70;
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
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-velocidad, 0)*Time.deltaTime;
            moviendose = true;
            miraIz = true;
            miraDer = false;
            miraFrente = false;
        }
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(velocidad, -0)*Time.deltaTime;
            moviendose = true;
            miraIz = false;
            miraDer = true;
            miraFrente = false;
        }
        if (Input.GetKey("w"))
        {
            rb.velocity = new Vector2(0, velocidad) *Time.deltaTime;
            moviendose = true;
            miraIz = false;
            miraDer = false;
            miraFrente = false;
        }
        if (Input.GetKey("s"))
        {
            rb.velocity = new Vector2(0, -velocidad) *Time.deltaTime;
            moviendose = true;
            miraIz = false;
            miraDer = false;
            miraFrente = true;
        }
        if (Input.GetKey("a") && Input.GetKey("w"))
        {
            rb.velocity = new Vector2(-velocidadDiagonal, velocidadDiagonal) * Time.deltaTime;
            moviendose = true;
            miraIz = true;
            miraDer = false;
            miraFrente = false;
        }
        if (Input.GetKey("d") && Input.GetKey("w"))
        {
            rb.velocity = new Vector2(velocidadDiagonal, velocidadDiagonal) * Time.deltaTime;
            moviendose = true;
            miraIz = false;
            miraDer = true;
            miraFrente = false;
        }
        if (Input.GetKey("a") && Input.GetKey("s"))
        {
            rb.velocity = new Vector2(-velocidadDiagonal, -velocidadDiagonal) * Time.deltaTime;
            moviendose = true;
            miraIz = true;
            miraDer = false;
            miraFrente = false;
        }
        if (Input.GetKey("d") && Input.GetKey("s"))
        {
            rb.velocity = new Vector2(velocidadDiagonal, -velocidadDiagonal) * Time.deltaTime;
            moviendose = true;
            miraIz = false;
            miraDer = true;
            miraFrente = false;
        }
        if (moviendose == false)
        {
            rb.velocity = new Vector2(0, 0);
            if (miraIz == true)
                thisSprite.sprite = LadoIz;
            else if (miraDer == true)
                thisSprite.sprite = LadoDer;
            else if (miraFrente == true)
                thisSprite.sprite = LadoF;
            else
                thisSprite.sprite = LadoAtras;
        }
        else
        {
            Animacion();
        }
    }
}
