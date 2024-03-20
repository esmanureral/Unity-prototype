using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos=new Vector3(25,0,0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;//oyun bittiðinde engel oluþmasýný durdurur.
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle",startDelay,repeatRate);//engel aralýklarla ortaya çýkar.
        
    }

    void Update()
    {
        
    }
    void SpawnObstacle() 
    { 
        if(playerControllerScript.gameOver==false) 
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
       
    }
}
