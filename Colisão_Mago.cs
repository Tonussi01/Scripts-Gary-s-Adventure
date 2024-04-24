using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisão_Mago : MonoBehaviour
{
    
    private Rigidbody2D RigidbodyPlayer;
    private Transform TransformPlayer;
    // Start is called before the first frame update
    void Start()
    {
        TransformPlayer = GetComponent<Transform>();
        RigidbodyPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("InstaKill_Tag"))
        {
            GameManager.inst.Vida = 0;
        }
    }
}
