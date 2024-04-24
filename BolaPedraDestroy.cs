using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaPedraDestroy : MonoBehaviour
{
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
          if (outro.gameObject.CompareTag("InstaKill_Tag"))
        {
             Destroy(this.gameObject);     
        }
    }
}
