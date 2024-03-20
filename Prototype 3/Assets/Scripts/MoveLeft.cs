using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController playerControllerScript;//engele �arpt���nda gameover yaz�s� g�rd���nde oyunun durmas�n� sa�lad�k.
    private float leftBound = -15;//engeller sahne d���nda silinmesi i�in
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(playerControllerScript.gameOver== false) 
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) 
        {
            Destroy(gameObject);
        }
    }
}
