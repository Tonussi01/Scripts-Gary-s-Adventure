using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public  static GameManager inst;
    public  Transform SpawnPlayer;
    public Slider SliderVida;
    public Slider SliderMana;
    public Text TextoMoedas;

    public int Vida;
    public int Mana;
    private bool restart;
    public bool vivo; 
    public  int faseAtual;   
    public  int ganhou;
    public  int Moeda;



   void Awake()
   {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
   
       Destroy(GameObject.Find("GameManager(Clone)"));
       if (inst == null)
       {
           inst = this;
           DontDestroyOnLoad(this.gameObject);
       }
       else
       {
           Destroy(gameObject);
       }
   }

    void Start()
    {
        Time.timeScale = 1;
        faseAtual       = 1;        
        Moeda           = 0;
        SliderVida.value = 100;
        SliderMana.value = 100;
        Vida = 100;
        Mana = 100;
    }
    void Update()
    {
        if (ganhou == 1)
        {
           // winPanel.SetActive(true);
        }
        if (ganhou == 2)
        {
            //losePanel.SetActive(true);
        }
        if (ganhou == 0)
        {
        }

        if(restart == true)
        {
           // StatusPartida.enabled = false;
            restart = false;
            ganhou    = 0;
            Moeda     = 0;
            //winPanel.SetActive(false);
            //losePanel.SetActive(false);
        }
        SliderVida.value = Vida;
        SliderMana.value = Mana;
        TextoMoedas.text = Convert.ToString(Moeda);

    }
}
