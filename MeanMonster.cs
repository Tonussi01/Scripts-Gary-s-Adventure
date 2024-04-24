using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeanMonster : MonoBehaviour
{

    private float tempo=0;
    public int Vida;
    private float UltimaAcao;
    private bool Face;
    private Transform   TransformMonster;
    
    public  Animator    AnimadorMonster;
    public GameObject moeda;
    private string Movimento;
    
    private float   VelocidadeAndando = 0.1f;
    private float   VelocidadeCorrendo = 0.2f;

    void Start()
    {
        TransformMonster = GetComponent<Transform>();
        AnimadorMonster  = GetComponent<Animator>(); 
        Andar();       
        Movimento = "C";
        UltimaAcao = tempo;
        Vida = 300;
    }

    void FixedUpdate()
    {
        tempo = Time.time;

        if(tempo > (UltimaAcao +5f))
        {
            Flip();
            TrocaMovimentacao();
            UltimaAcao = tempo;
        }
        if(tempo > (UltimaAcao +3f))
        {
            TrocaMovimentacao();
        }

        // A = Andar / C = Correr 
        if((Movimento == "A") && (Face == true))
        {                
            transform.Translate(VelocidadeAndando,0,0);
        }
        if((Movimento == "A") && (Face == false))
        {
            transform.Translate(-VelocidadeAndando,0,0);
        }
        if((Movimento == "C") && (Face == true))
        {
            transform.Translate(VelocidadeCorrendo,0,0);
        }
        if((Movimento == "C") && (Face == false))
        {
            transform.Translate(-VelocidadeCorrendo,0,0);
        }

        if(Vida <= 0)
        {   
            Morrer();            
        }
    }

     private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("Magia_Tag") )
        {
            Vida -=80;
        }        
    }

    void TrocaMovimentacao()
    {
        if(Movimento == "A")
        {
            Correr();
            //transform.Translate(1f,0,0);
        }
        else
        {
            Andar();
            //transform.Translate(1f,0,0);
        }
    }

    void Flip()
    {
        Face                = !Face;
        Vector3 scala       = TransformMonster.localScale;
        scala.x             *= -1;
        TransformMonster.localScale   = scala;
    }
    private void Andar()
    {       
        AnimadorMonster.SetBool("Idle", false);
        AnimadorMonster.SetBool("Andando", true);       
        AnimadorMonster.SetBool("Correndo", false);  
        Movimento = "A";
    }
    private void Correr()
    {
        AnimadorMonster.SetBool("Idle", false);
        AnimadorMonster.SetBool("Andando", false);       
        AnimadorMonster.SetBool("Correndo", true);  
        Movimento = "C";
    }

    private void Morrer()
    {
        GameObject newMoedas = Instantiate(moeda, gameObject.transform.position, Quaternion.identity);       
        Destroy(gameObject);
    }
}
