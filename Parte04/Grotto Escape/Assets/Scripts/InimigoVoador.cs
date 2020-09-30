using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class InimigoVoador : Inimigo
{   
    //Reescrevendo o metodo Update
    protected override void Update()
    {
        //Executando metodo Update original
        base.Update();

        if(EstaAndando == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Jogador.transform.position, Mathf.Abs(Velocidade) * Time.deltaTime);
        }
    }
}
