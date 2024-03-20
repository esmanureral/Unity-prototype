using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour

{
    public float horizontalInput;
    public float speed = 18.0f;
    public float xRange = 20;
    public GameObject projectPrefab; 
    //yukarýdaki deðiþkeni pizzayý mermi gibi atabilmemiz için yazdý.
    //daha sonra hiyerarþideki player e týklayým project Prefab e pizzayý seçtik.


    void Start()
    {
        
    }

    void Update()
    {
        /*if (transform.position.x < -20)
        {
            transform.position = new Vector3(-20,transform.position.y,transform.position.z);
        }
        bu if i yataykontrolden sonra yazdýk.Playerin sahne dýþýna çýkmasýný engeller.*/

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x>xRange)
        {
            transform.position=new Vector3(xRange,transform.position.y,transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");//yataytuþlar
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //yukarýdaki satýr playerin yatay doðrultuda hareket etmesini saðlar x ekseninde gidip gelir.

        if ((Input.GetKeyDown(KeyCode.Space))){
            Instantiate(projectPrefab, transform.position, projectPrefab.transform.rotation);

        }
        //bu if yapýsý space basýldýðýnda otomatik pizzalarý mermi gibi fýrlatýr.

    }
}
