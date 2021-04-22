using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Script for Player 1


    public float speed = 10f;
    public static float LifeTime = 0.4f;

    //Particle System
    public GameObject Particle;
    public GameObject BloodSplatter;


    public Rigidbody2D rb;
    private bool Hit;

    //ScreenShake
    private Shake shake;

   

    void Start()
    {
        rb.velocity = transform.up * speed;
        Invoke("DestroyBullet", LifeTime);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player2"))
        {
            Destroy(gameObject);

            //Particle effect for when bullet hits player
            GameObject effect = Instantiate(BloodSplatter) as GameObject;
            effect.transform.position = this.transform.position;
        
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);

            //Particle effect for when bullet hits the wall
            GameObject effect = Instantiate(Particle) as GameObject;
            effect.transform.position = this.transform.position;

            shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
            shake.CamShake();
        }
    }


    void DestroyBullet()
    {
        Destroy(gameObject);
    }


}
