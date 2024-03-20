using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint; //odak noktasýna bir referans aldýk.
    public float speed = 5.0f;
    public bool hasPowerup = false; //çarpýþtýðýnda yok etmek
    private float powerupStrength = 15.0f;//güçlenme gücü
    public GameObject powerupIndicator;//güç alma göstergesi

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        //find: proje hiyerarþinde o oyun nesnesini bulur.

    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        // playerRb.AddForce(Vector3.forward* forwardInput*speed);

        if (playerRb != null && focalPoint != null)
        {
            playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());//güçlendirme süresi sayacýný baþlatmak 
            powerupIndicator.gameObject.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody=collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with" + collision.gameObject.name + "with powerup set to" + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }

    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
