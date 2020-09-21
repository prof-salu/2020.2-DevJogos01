using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float velocidade = 8;
    public float timerDestruicao = 1;
    void Start()
    {
        Destroy(gameObject, timerDestruicao);
    }

    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);        
    }
}
