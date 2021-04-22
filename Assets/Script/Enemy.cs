using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //Script For Player 2

    public int health = 5;
   

    public Slider Health;

    private void Start()
    {
        Health.value = health;
    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
            Health.value--;
         

            if(health <= 0)
            {
                KillSelf();
            }
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("MedKit"))
        {
            if (health <= 4)
            {
                health += 2;
                Health.value += 2;
            }
        }

        if (collider.gameObject.CompareTag("Platform"))
        {
            if (health >= 0)
            {
                health--;
                Health.value--;
            }

            if (health <= 0)
            {
                KillSelf();
            }

        }

    }


    private void KillSelf()
    {
        gameObject.SetActive(false);
        Score.scoreValue1 += 1;

        Bullet2.LifeTime += 0.2f;
    }

}