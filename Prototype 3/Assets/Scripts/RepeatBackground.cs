using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;//arka planýn sürekli devam etmesi için
    private float repeatWidth;//tekrargeniþliði
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
