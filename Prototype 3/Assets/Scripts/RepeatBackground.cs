using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;//arka plan�n s�rekli devam etmesi i�in
    private float repeatWidth;//tekrargeni�li�i
    void Start()
    {
        startPos = transform.position;
        repeatWidth=GetComponent<BoxCollider>().size.x/2;
    }

    void Update()
    {
        if(transform.position.x< startPos.x - repeatWidth) 
        {
            transform.position= startPos;
        }
        
    }
}
