using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMute : MonoBehaviour
{
    // Start is called before the first frame update
    void update()
    {
         
    }
    public void mutar()
    {       
        AudioListener.volume = 0f;    
    }
}
