using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explosion;

    [SerializeField]
    private int damageTank1, damageTank2, damageTank3;

 
    private int tankNumber;

   
    private PlayerHealth playerHealth;
    private AudioSource audioExplosion;

    private void Start()
    {
        audioExplosion = GetComponent<AudioSource>();
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        tankNumber = TankManager.instance.tank;


    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            explosion.Play();
            audioExplosion.Play();

            if (tankNumber == 0)
            {
                playerHealth.ApplyDamage(damageTank1);
            }
            else if (tankNumber == 1)
            {
                playerHealth.ApplyDamage(damageTank2);
            }
            else if (tankNumber == 2)
            {
                playerHealth.ApplyDamage(damageTank2);
            }

            Destroy(gameObject, 0.3f);
        }


        if (collision.gameObject.CompareTag("Bullet"))
        {
            explosion.Play();
            audioExplosion.Play();

            Destroy(gameObject, 0.3f);
            Destroy(collision.gameObject);

        }






    }


  










}
