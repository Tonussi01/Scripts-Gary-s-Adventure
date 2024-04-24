using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PlataformaSuspensa : MonoBehaviour
{
    public bool Posicao;
    public int velocidade;
    void Start()
    {
        Posicao = true;
    }

    
    void FixedUpdate()
    {
         Movimenta();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Poste_Tag") || col.gameObject.CompareTag("PlataformaSuspensa_Tag"))
        {
            inverte();
        }
    }
    void inverte()
    {
        Posicao = !Posicao; 
    }

    void Movimenta()
    {
        if(Posicao)
        transform.Translate(new Vector2(velocidade * Time.deltaTime, 0));
        else
        transform.Translate(new Vector2(-velocidade * Time.deltaTime, 0));
    }
}
