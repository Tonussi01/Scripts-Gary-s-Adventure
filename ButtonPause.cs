using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{   
    public GameObject PausePanel;
    public GameObject BotaoDir;
    public GameObject BotaoEsq;
    public GameObject BotaoPulo;
    public GameObject BotaoMagia;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
     public void PauseGame()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        BotaoDir.SetActive(false);
        BotaoEsq.SetActive(false);
        BotaoPulo.SetActive(false);
        BotaoMagia.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        BotaoDir.SetActive(true);
        BotaoEsq.SetActive(true);
        BotaoPulo.SetActive(true);
        BotaoMagia.SetActive(true);
    }
    public void CloseGame()
    {
        Application.Quit();
    }

}
