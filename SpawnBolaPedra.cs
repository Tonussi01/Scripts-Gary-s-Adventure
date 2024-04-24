using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBolaPedra : MonoBehaviour
{
    public GameObject PedraGrande;
    private float tempo=0;
    private float UltimaAcao;
    void Update()
    {
         tempo = Time.time;

        if(tempo > (UltimaAcao +5f))
        {
            InstanciaPedra();
            UltimaAcao = tempo;
        }
    }

    void InstanciaPedra()
    {
        GameObject newRock = Instantiate(PedraGrande, this.transform.position, Quaternion.identity);
    }
}
