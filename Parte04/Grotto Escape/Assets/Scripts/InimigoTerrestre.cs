using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoTerrestre : Inimigo
{
    private void FixedUpdate()
    {
        if(EstaAndando == true)
        {
            rb.velocity = new Vector2(Velocidade, rb.velocity.y);
        }
    }
}
