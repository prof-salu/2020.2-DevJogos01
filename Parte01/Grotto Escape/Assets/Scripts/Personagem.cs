using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public float velMax = 5;
    public float forcaPulo = 150;

    private bool estaPulando = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Awake()
    {
        //Debug.Log("Apareceu Awake");
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();        
    }

    private void Start()
    {
        //Debug.Log("Apareceu Start");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            estaPulando = true;
        }
    }

    private void FixedUpdate()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        //Debug.Log(movHorizontal);
        rb.velocity = new Vector2(movHorizontal * velMax, rb.velocity.y);

        if((movHorizontal > 0 && sprite.flipX == true) || movHorizontal < 0 && sprite.flipX == false)
        {
            InverteSprite();
        }
        
        if(estaPulando == true)
        {
            Pular();
        }
    }

    private void Mover() { 
        
    }

    private void InverteSprite()
    {
        sprite.flipX = !sprite.flipX;
    }

    private void Pular()
    {
        rb.AddForce(Vector2.up * forcaPulo);
        estaPulando = false;
    }
}