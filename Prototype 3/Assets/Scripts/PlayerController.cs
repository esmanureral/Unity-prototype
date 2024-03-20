using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    private Animator playerAnim;//atlama animasyonu
    public ParticleSystem explosionParticle;//çarptığında parçacık efekti
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;//zıplamasesi
    public AudioClip crashSound;//çarpışmasesi
    private AudioSource playerAudio;//sesiyaymakiçin
   
    
    public float JumpForce = 10; //zıplamagücü
    public float gravityModifier; //yerçekimdeğiştirici
    public bool İsOnGround = true; //bu değişken oyunucunun bir kere zıplamasına izin verir.Çift zıplamayı engeller.
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
        if (Input.GetKeyDown(KeyCode.Space)&& İsOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            İsOnGround=false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
      
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            İsOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);//düşme animasyonu
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
       
    }
}
