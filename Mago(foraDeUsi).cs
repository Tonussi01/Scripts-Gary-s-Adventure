using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System.Threading;

public class Mago : MonoBehaviour
{
    public  static Mago inst;
    private bool    Vivo;    
    public  bool    Face = true;
    private bool    LiberaPulo = true;
    private float   Forca = 6f;    
    private float   VelocidadeAndando = 3.5f;
    private float   VelocidadeCorrendo = 6f;
    public int      Vida;
    public int      Mana;
    
    public  Animator    AnimadorPlayer;
    private Rigidbody2D RigidbodyPlayer;
    private Transform   TransformPlayer;
    private Transform   MaoEsquerda;
    public  GameObject MagiaAzul;
    
    

    void Start()
    {
        Vida            = 100;
        Mana            = 100;
        Vivo            = true;
        TransformPlayer = GetComponent<Transform>();
        RigidbodyPlayer = GetComponent<Rigidbody2D>(); 
        AnimadorPlayer  = GetComponent<Animator>(); 
        MaoEsquerda     = GetComponent<Transform>();
        AnimadorPlayer.SetBool("Vivo", true);
        AnimadorPlayer.SetBool("Idle", false);
        AnimadorPlayer.SetBool("Pulando", true);
        AnimadorPlayer.SetBool("Correndo", false);           
        AnimadorPlayer.SetBool("Andando", false);                   
        AnimadorPlayer.SetBool("LancandoMagia", false);  
    }

    void FixedUpdate()
    {
        if (Vivo == true)
        {
            //Flipa Face
            if (Input.GetKey(KeyCode.D) && !Face)
            {
                Flip();
            }
            else if (Input.GetKey(KeyCode.A) && Face)
            {
                Flip();    
            }

            //ANDAR
            else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKeyDown(KeyCode.Space))
            {
                transform.Translate(new Vector2(VelocidadeAndando * Time.deltaTime, 0));
                Andar();
            }
            else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKeyDown(KeyCode.Space))
            {
                transform.Translate(new Vector2(-VelocidadeAndando * Time.deltaTime, 0));
                Andar();
            }

            //Correr
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(new Vector2(VelocidadeCorrendo * Time.deltaTime, 0));
                Correr();
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(new Vector2(-VelocidadeCorrendo * Time.deltaTime, 0));
                Correr();
            }
            //IDLE
            else 
            {
                Idle();
            }

            //Pular
            if (Input.GetKey(KeyCode.Space) && LiberaPulo == true )
            {                
                Pular();
                RigidbodyPlayer.AddForce(new Vector2(0, Forca * 1.5f), ForceMode2D.Impulse);
                LiberaPulo = false;
            } 
            //Magia
            if (Input.GetKeyDown(KeyCode.C) && Mana > 20 )
            {                
                LancaMagia();
            }             
        }

        else
        {
            Morre();
        }
        GameManager.inst.Vida = Vida;
        GameManager.inst.Mana = Mana;

    }
    
    private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("Chao_Tag") || outro.gameObject.CompareTag("Parede_Tag") )
        {
            LiberaPulo = true;
            AnimadorPlayer.SetBool("Pulando", false);
        }
        if (outro.gameObject.CompareTag("MeanMonster_Tag"))
        {
            RigidbodyPlayer.AddForce(new Vector2(5, 2), ForceMode2D.Impulse);
            Vida -= 20;            
        }
    }

    void Flip()
    {
        Face                = !Face;
        Vector3 scala       = TransformPlayer.localScale;
        scala.x             *= -1;
        TransformPlayer.localScale   = scala;
    }


    public void Andar()
    {    
        AnimadorPlayer.SetBool("Idle", false);
        AnimadorPlayer.SetBool("Andando", true);       
        AnimadorPlayer.SetBool("Correndo", false);  
    }

    public void Correr()
    {    
        AnimadorPlayer.SetBool("Idle", false);
        AnimadorPlayer.SetBool("Andando", false);
        AnimadorPlayer.SetBool("Correndo", true);      
    }

    public void Pular()
    {    
        AnimadorPlayer.SetBool("Idle", false);
        AnimadorPlayer.SetBool("Pulando", true);
        //AnimadorPlayer.SetBool("Correndo", false);           
        //AnimadorPlayer.SetBool("Andando", false);  
    }

    public void Idle()
    {    
        AnimadorPlayer.SetBool("Idle", true);
        AnimadorPlayer.SetBool("Pulando", false);
        AnimadorPlayer.SetBool("Correndo", false);           
        AnimadorPlayer.SetBool("Andando", false);                   
        AnimadorPlayer.SetBool("LancandoMagia", false);   
    } 

    public void Morre()
    {        
        //AnimadorPlayer.SetBool("Vivo", false);
    }
    public void LancaMagia()
    {
        AnimadorPlayer.SetBool("Idle", false);
        AnimadorPlayer.SetBool("LancandoMagia", false);    
        GameObject NewMagic = Instantiate(MagiaAzul, MaoEsquerda.position,MagiaAzul.transform.rotation);
    }
    
}
