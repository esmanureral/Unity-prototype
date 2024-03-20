using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour

{
    public float horizontalInput;
    public float speed = 18.0f;
    public float xRange = 20;
    public GameObject projectPrefab; 
    //yukar�daki de�i�keni pizzay� mermi gibi atabilmemiz i�in yazd�.
    //daha sonra hiyerar�ideki player e t�klay�m project Prefab e pizzay� se�tik.


    void Start()
    {
        
    }

    void Update()
    {
        /*if (transform.position.x < -20)
        {
            transform.position = new Vector3(-20,transform.position.y,transform.position.z);
        }
        bu if i yataykontrolden sonra yazd�k.Playerin sahne d���na ��kmas�n� engeller.*/

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x>xRange)
        {
            transform.position=new Vector3(xRange,transform.position.y,transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");//yataytu�lar
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //yukar�daki sat�r playerin yatay do�rultuda hareket etmesini sa�lar x ekseninde gidip gelir.

        if ((Input.GetKeyDown(KeyCode.Space))){
            Instantiate(projectPrefab, transform.position, projectPrefab.transform.rotation);

        }
        //bu if yap�s� space bas�ld���nda otomatik pizzalar� mermi gibi f�rlat�r.

    }
}
