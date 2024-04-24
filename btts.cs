using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btts : MonoBehaviour
{
    public GameObject BotaoMutado;
    public Text TextBotaoMute;
    public GameObject BotaoDesmutado;
    public GameObject BotaoDir;
    public GameObject BotaoEsq;
    public GameObject BotaoPulo;
    public GameObject BotaoMagia;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( AudioListener.volume > 0)
        {
            BotaoMutado.SetActive(false);
            BotaoDesmutado.SetActive(true);    
            TextBotaoMute.text = "Som Ativado!";
        }
        else
        {
            BotaoMutado.SetActive(true);   
            BotaoDesmutado.SetActive(false);   
            TextBotaoMute.text = "Som Desativado!";
        }
    }
}
