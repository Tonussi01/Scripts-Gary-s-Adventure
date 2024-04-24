using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancaMagiaAzul : MonoBehaviour
{

    private Transform local;
    public  GameObject MagiaAzul;
    // Start is called before the first frame update
    void Start()
    {
         local = GetComponent<Transform>();
         GameObject newBomb = Instantiate(MagiaAzul, local.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
