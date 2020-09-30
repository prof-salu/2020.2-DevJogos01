using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float velocidade = 8;
    public float timerDestruicao = 1;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, timerDestruicao);
        rb.velocity = transform.right * velocidade;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    void Update()
    {
        //transform.Translate(Vector2.right * velocidade * Time.deltaTime);        
    }
}
