using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlorTrampolim : MonoBehaviour
{
    public  Animator    AnimadorFlor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("Player_Tag"))
        {
            AnimadorFlor.SetBool("Pula", true);
        }
    }

    private void OnCollisionExit2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("Player_Tag"))
        {
          AnimadorFlor.SetBool("Pula", false);
        }        
    }
}
