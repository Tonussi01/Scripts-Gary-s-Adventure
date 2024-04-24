using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonFase2 : MonoBehaviour
{
    public GameObject  BotaoF1;
    public GameObject  BotaoF2;
    public GameObject  TextoF1;
    public GameObject  TextoF2;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        BotaoF1.SetActive(false);
        TextoF1.SetActive(false);
        BotaoF2.SetActive(true);
        TextoF2.SetActive(true);
    }
}
