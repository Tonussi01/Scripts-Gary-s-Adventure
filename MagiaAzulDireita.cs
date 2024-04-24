using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagiaAzulDireita : MonoBehaviour
{
    
    public  Animator    animador_Mago;
    float x,y,z;
    private Transform   MagiaTransform;
    
    void Start()
    {
        MagiaTransform = GetComponent<Transform>();
        animador_Mago.SetBool("LancandoMagia", false);
    }

    
    void Update()
    {
        x = 0.1f;
        y = 0;
        z = 0;

        MagiaTransform.Translate(x,y,z);
        
        Destroy(gameObject,1.5f);
    }
     private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("MeanMonster_Tag"))
        {
           Destroy(gameObject);
        }        
    }
}