using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
    //kamera odak noktas� i�in

   
{
    public float rotationSpeed;
    void Start()
    {
        
    }

    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up,horizontalInput*rotationSpeed*Time.deltaTime);
    }
}
