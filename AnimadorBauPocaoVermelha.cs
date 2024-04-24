using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimadorBauPocaoVermelha : MonoBehaviour
{    
    public GameObject Pocao;
    public  Animator    AnimadorBau;
    public  Animator    AnimadorPocao;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player_Tag"))

        {
           AbreBau();
        }
    }
    private void AbreBau()
    {
        AnimadorBau.SetBool("Aberto", true);
        MovePocao();
    }

    private void MovePocao()
    {   
        Pocao.SetActive(true);
        AnimadorPocao.SetBool("Subiu", true);
    }


}
