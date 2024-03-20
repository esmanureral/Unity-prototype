using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    private Animator playerAnim;//atlama animasyonu
    public ParticleSystem explosionParticle;//çarptýðýnda parçacýk efekti
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;//zýplamasesi
    public AudioClip crashSound;//çarpýþmasesi
    private AudioSource playerAudio;//sesiyaymakiçin
   
    
    public float JumpForce = 10; //zýplamagücü
    public float gravityModifier; //yerçekimdeðiþtirici
    public bool ÝsOnGround = true; //bu deðiþken oyunucunun bir kere zýplamasýna izin verir.Çift zýplamayý engeller.
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
        if (Input.GetKeyDown(KeyCode.Space)&& ÝsOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            ÝsOnGround=false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
      
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ÝsOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);//düþme animasyonu
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
       
    }
}
