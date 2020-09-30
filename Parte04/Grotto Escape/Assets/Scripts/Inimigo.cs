using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float Velocidade;
    public float RaioDeAtaque = 1;

    protected bool EstaAndando;

    protected Rigidbody2D rb;
    protected SpriteRenderer sprite;
    protected GameObject Jogador;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        Jogador = GameObject.FindGameObjectWithTag("Jogador");
    }

    //Apenas metodos declarados como virtual podem ser reescritos
    protected virtual void Update()
    {
        EstaAndando = (DistanciaParaJogador() <= RaioDeAtaque);

        if(EstaAndando == true)
        {
            if(Jogador.transform.position.x > transform.position.x && sprite.flipX ||
                Jogador.transform.position.x < transform.position.x && !sprite.flipX)
            {
                InverteSprite();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tiro"))
        {
            Destroy(gameObject);
        }
    }

    private float DistanciaParaJogador()
    {
        float distancia;

        distancia = Vector2.Distance(Jogador.transform.position, gameObject.transform.position);

        return distancia;
    }

    private void InverteSprite()
    {
        sprite.flipX = !sprite.flipX;
        Velocidade *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, RaioDeAtaque);
    }
}