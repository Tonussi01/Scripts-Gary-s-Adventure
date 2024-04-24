using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Inimigo : MonoBehaviour
{
    private float tempoRotacao = 0;
    private float raio;
    public Rigidbody2D rb;
    public ConstantForce2D constantForce2;
    public float velocidade ;

    private float x;


    // Start is called before the first frame update
    void Start()
    {
        x = 1;
    }


    // Update is called once pear frame
    void Update()
    {

    }


    void FixedUpdate()
    {
        if (rb != null)
        {
            AplicaForca();
        }
    }

    public void AplicaForca()
    {
      
        float xforca =  velocidade * Time.deltaTime;

        if (x == 1)
        {
            Vector2 forca = new Vector2(xforca, 0);
            rb.velocity = new Vector2(xforca, rb.velocity.y);
        }
        else
        {
            Vector2 forca = new Vector2(-xforca, 0);
            rb.velocity = new Vector2(-xforca,rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("parede_tag"))
        {
            x *= -1;
        }
        if (col.gameObject.CompareTag("lamina_tag"))
        {
            x *= -1;
        }

    }
}
