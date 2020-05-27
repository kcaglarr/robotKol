using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierMove : MonoBehaviour
{
    public float hiz=20;
    
    void Update()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * hiz * -Input.GetAxis("Horizontal");


        
    }
}
