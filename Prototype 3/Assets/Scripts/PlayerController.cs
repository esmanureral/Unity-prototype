using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    private Animator playerAnim;//atlama animasyonu
    public ParticleSystem explosionParticle;//�arpt���nda par�ac�k efekti
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;//z�plamasesi
    public AudioClip crashSound;//�arp��masesi
    private AudioSource playerAudio;//sesiyaymaki�in
   
    
    public float JumpForce = 10; //z�plamag�c�
    public float gravityModifier; //yer�ekimde�i�tirici
    public bool �sOnGround = true; //bu de�i�ken oyunucunun bir kere z�plamas�na izin verir.�ift z�plamay� engeller.
    public bool gameOver;

    void Start()
    {
        playerRb=GetComponent<Rigidbody>();
        Physics.gravity*=gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& �sOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            �sOnGround=false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
      
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            �sOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);//d��me animasyonu
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
       
    }
}
