using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public float velMax = 5;
    public float forcaPulo = 150;
    public float raioDosPes = 0.5f;
    public Transform posicaoDosPes;

    private bool estaPulando = false;
    private bool estaAndando = false;
    private bool estaNoChao = false;

    private float movHorizontal;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animacao;

    private void Awake()
    {
        //Debug.Log("Apareceu Awake");
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animacao = GetComponent<Animator>();
    }

    private void Update()
    {
        movHorizontal = Input.GetAxis("Horizontal");

        Debug.Log(movHorizontal);

        if (Input.GetButtonDown("Jump") && estaNoChao == true)
        {
            estaPulando = true;
        }        

        animacao.SetBool("Andando", estaAndando);
        animacao.SetBool("Pulando", !estaNoChao);

        //estaAndando = rb.velocity.x != Vector2.zero.x;
    }

    private void FixedUpdate()
    {
        estaNoChao = Physics2D.OverlapCircle(posicaoDosPes.position, raioDosPes, LayerMask.GetMask("Chao"));

        Mover();
                
        Pular();

        estaAndando = rb.velocity.x != Vector2.zero.x;

    }

    private void Mover()
    {
        rb.velocity = new Vector2(movHorizontal * velMax, rb.velocity.y);
        InverteSprite();
    }

    private void InverteSprite()
    {
        if ((movHorizontal > 0 && sprite.flipX == true) || movHorizontal < 0 && sprite.flipX == false)
        {
            sprite.flipX = !sprite.flipX;
        }            
    }

    private void Pular()
    {
        if (estaPulando == true)
        {
            rb.AddForce(Vector2.up * forcaPulo);
            estaPulando = false;
        }            
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(posicaoDosPes.position, raioDosPes);
    }
}