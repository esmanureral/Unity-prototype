using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody enemeyRb;
    private GameObject player;
    void Start()
    {
        enemeyRb=GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        
    }

    
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemeyRb.AddForce(lookDirection*speed);
      //  enemeyRb.AddForce((player.transform.position - transform.position).normalized * speed);
      if(transform.position.y<-10) 
        {
            Destroy(gameObject);
        }
    }
}
