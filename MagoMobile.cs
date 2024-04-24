using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MagoMobile : MonoBehaviour
{
    public  static Mago inst;
     private int tempo = 0;
    public bool    Vivo;    
    public  bool    Face = true;
    public bool    LiberaPulo = true;
    private float   Forca = 7.5f;    
    private float   VelocidadeAndando = 7f;
    private float   VelocidadeCorrendo = 7f;
    public int      Vida;
    public int      Mana;
    
    private bool    moveDir,moveEsq;
    
    public  Animator    AnimadorPlayer;
    private Rigidbody2D RigidbodyPlayer;
    private Transform   TransformPlayer;

    [SerializeField]
    private Transform   SpawnMagiaAzulEsq;
    [SerializeField]
    private Transform   SpawnMagiaAzulDir;

    public  GameObject MagiaAzulDireita;
    public  GameObject MagiaAzulEsquerda;
    
    [SerializeField]
    private EventTrigger eventTriggerPulo,eventTriggerMagiaAzul,eventTriggerDireita,eventTriggerEsquerda;
    [SerializeField]
    private EventTriggerType tipoPulo,tipoMagiaAzul,tipoDireita,tipoEsquerda;
    [SerializeField]
    private EventTrigger.Entry entryPulo,entryMagiaAzul,entryDireitaD,entryDireitaU,entryEsquerdaD,entryEsquerdaU;

    [SerializeField]
    private Image btnPulo,btnMagia,btnDir,btnEsq;
    private float RegenMana;

    void Awake()
    {
        btnPulo = GameObject.FindWithTag("Joy_Pulo_Tag").GetComponent<Image>();
        btnDir = GameObject.FindWithTag("Joy_Direita_Tag").GetComponent<Image>();
        btnEsq = GameObject.FindWithTag("Joy_Esquerda_Tag").GetComponent<Image>();        
        btnMagia = GameObject.FindWithTag("Joy_MagiaAzul_Tag").GetComponent<Image>();

        eventTriggerPulo = btnPulo.GetComponent<EventTrigger>();
        eventTriggerMagiaAzul = btnMagia.GetComponent<EventTrigger>();
        eventTriggerDireita = btnDir.GetComponent<EventTrigger>();
        eventTriggerEsquerda = btnEsq.GetComponent<EventTrigger>();
        
    }

    void Start()
    {
        Vida            = 100;
        Mana            = 100;
        Vivo            = true;
        TransformPlayer = GetComponent<Transform>();
        RigidbodyPlayer = GetComponent<Rigidbody2D>(); 
        AnimadorPlayer  = GetComponent<Animator>(); 
        AnimadorPlayer.SetBool("Vivo", true);
        AnimadorPlayer.SetBool("Idle", false);
        AnimadorPlayer.SetBool("Pulando", true);
        AnimadorPlayer.SetBool("Correndo", false);           
        AnimadorPlayer.SetBool("Andando", false);                   
        AnimadorPlayer.SetBool("LancandoMagia", false);  

        AjustaJoyDown(tipoPulo,entryPulo);
        entryPulo.callback.AddListener((data) => {PuloJoy((PointerEventData)data);});

        AjustaJoyDown(tipoMagiaAzul,entryMagiaAzul);
        entryMagiaAzul.callback.AddListener((data) => {MagiaJoy((PointerEventData)data);});

        AjustaJoyDown(tipoDireita,entryDireitaD);
        entryDireitaD.callback.AddListener((data) => {MoveDir((PointerEventData)data);});

        AjustaJoyUp(tipoDireita,entryDireitaU);
        entryDireitaU.callback.AddListener((data) => {MoveDirPara((PointerEventData)data);});

        AjustaJoyDown(tipoEsquerda,entryEsquerdaD);
        entryEsquerdaD.callback.AddListener((data) => {MoveEsq((PointerEventData)data);});

        AjustaJoyUp(tipoEsquerda,entryEsquerdaU);
        entryEsquerdaU.callback.AddListener((data) => {MoveEsqPara((PointerEventData)data);});


        GatilhosBtn(eventTriggerPulo,entryPulo);
        GatilhosBtn(eventTriggerMagiaAzul,entryMagiaAzul);
        GatilhosBtn(eventTriggerDireita,entryDireitaD);
        GatilhosBtn(eventTriggerDireita,entryDireitaU);
        GatilhosBtn(eventTriggerEsquerda,entryEsquerdaD);
        GatilhosBtn(eventTriggerEsquerda,entryEsquerdaU);
    }
    void AjustaJoyDown(EventTriggerType tipo,EventTrigger.Entry entry)
    {
        tipo = EventTriggerType.PointerDown;
        entry.eventID = tipo;
    }

    void AjustaJoyUp(EventTriggerType tipo,EventTrigger.Entry entry)
    {
        tipo = EventTriggerType.PointerUp;
        entry.eventID = tipo;
    }

    void GatilhosBtn(EventTrigger eventTrigger,EventTrigger.Entry entry)
    {
        eventTrigger.triggers.Add(entry);
    }

    void FixedUpdate()
    {
        tempo = Convert.ToInt32(Time.time);

        if(tempo > (RegenMana +1f))
        {            
            RegenMana = tempo;  
            if(Mana<100)          
            Mana += 15;
            if(Vida<100)
            Vida +=5;
        }        
        
        if (Vivo == true)
        {
            //Flipa Face
            if ((moveDir) && !Face)
            {
                Flip();
            }
            else if ((moveEsq) && Face)
            {
                Flip();    
            }            
            
            else if(moveDir)
            {
                transform.Translate(new Vector2(VelocidadeAndando * Time.deltaTime, 0));
                Correr();
            }
            else if(moveEsq)
            {
                transform.Translate(new Vector2(-VelocidadeAndando * Time.deltaTime, 0));
                Correr();
            }     

            //IDLE
            else 
            {
                Idle();
            }
        }

        else
        {
            morre();
        }
        GameManager.inst.Vida = Vida;
        GameManager.inst.Mana = Mana;

        if(Vida <= 0)
        {
            Vivo = false;
            GameManager.inst.vivo = false;            
            GameManager.inst.ganhou = 2;
        }
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

        if (outro.gameObject.CompareTag("Flor_Tag"))
        {
            Pular();
            RigidbodyPlayer.AddForce(new Vector2(0, Forca * 2.5f), ForceMode2D.Impulse);            
            LiberaPulo = false;  
        }
    }

     void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ChamaFogo_Tag"))
        {
            RigidbodyPlayer.AddForce(new Vector2(5, 2), ForceMode2D.Impulse);
            Vida -= 50;   
        }
    }

    public void PuloJoy(PointerEventData data )
    {
        if(LiberaPulo)
        {
            Pular();
            RigidbodyPlayer.AddForce(new Vector2(0, Forca * 1.5f), ForceMode2D.Impulse);            
            LiberaPulo = false;                     
        }
    }
    public void MagiaJoy(PointerEventData data )
    {
        if(Mana>10)
        LancaMagia();
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
    }

    public void Idle()
    {    
        AnimadorPlayer.SetBool("Idle", true);
        AnimadorPlayer.SetBool("Pulando", false);
        AnimadorPlayer.SetBool("Correndo", false);           
        AnimadorPlayer.SetBool("Andando", false);                   
        AnimadorPlayer.SetBool("LancandoMagia", false);   
    }

    public void morre()
    { AnimadorPlayer.SetBool("vivo", false); }
    
    public void LancaMagia()
    {
        AnimadorPlayer.SetBool("Idle", false);
        AnimadorPlayer.SetBool("LancandoMagia", true);    
        Mana -=25;       

        if(!Face)
        {
        GameObject NewMagicDir = Instantiate(MagiaAzulEsquerda, SpawnMagiaAzulEsq.position,(SpawnMagiaAzulEsq.transform.rotation));   
        }
        else
        { 
        GameObject NewMagicEsq = Instantiate(MagiaAzulDireita, SpawnMagiaAzulEsq.position,(SpawnMagiaAzulEsq.transform.rotation));
        }      
    }
        public void MoveDir(PointerEventData data )
    {
        moveDir = true;
    }

    public void MoveDirPara(PointerEventData data )
    {
        moveDir = false;
    }

    public void MoveEsq(PointerEventData data )
    {
        moveEsq = true;
    }

    public void MoveEsqPara(PointerEventData data )
    {
        moveEsq = false;
    }
    
}
