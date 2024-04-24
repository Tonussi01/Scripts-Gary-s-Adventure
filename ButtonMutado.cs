using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMutado : MonoBehaviour
{  
        
    void update()
    {
        if( AudioListener.volume > 0)
        {
            this.gameObject.SetActive(false);        
        }
        else
        {
            this.gameObject.SetActive(true);    
        }
    }
        public void desmutar()
    {       
        AudioListener.volume = 0.6f;    
    }
    
}
