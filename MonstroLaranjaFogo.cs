using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MonstroLaranjaFogo : MonoBehaviour
{
    public Animator AnimadorMonster;

    private float tempo = 0;
    public int Vida;

    private float UltimaAcao;
    private bool Face;

    public GameObject Fogo;
    public Transform local;

    void Start()
    {
        AnimadorMonster = GetComponent<Animator>();
        Vida = 350;
    }

    void FixedUpdate()
    {
        tempo = Time.time;

        if (tempo > (UltimaAcao + 6.5f))
        {
            UltimaAcao = tempo;
            CospeFogo();
            GameObject newFogo = Instantiate(Fogo, local.position, local.rotation);
        }

        if (Vida <= 0)
        {
            Morrer();
        }
    }

    private void Andar()
    {
        AnimadorMonster.SetBool("Idle", false);
        AnimadorMonster.SetBool("Andando", true);
        AnimadorMonster.SetBool("Boca", false);
    }


    private void CospeFogo()
    {
        AnimadorMonster.SetBool("Idle", false);
        AnimadorMonster.SetBool("Boca", true);        
    }

    private void Morrer()
    {        
        Destroy(gameObject);
    }

     private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("Magia_Tag") )
        {
            Vida -=30;
        }        
    }


}
