using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Transform player;

    [SerializeField]
    private int damageTank1, damageTank2, damageTank3;

    private float missileSpeed = 10f;

    [SerializeField]
    private ParticleSystem explosionEffect;

    private AudioSource explosionSound;

    private Vector3 targetPos;
    private PlayerHealth playerHealth;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();

        explosionSound = GetComponent<AudioSource>();


        targetPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        transform.rotation = Quaternion.Euler(0, 270, 0);

    }

    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, targetPos, missileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Player"))
        {

            explosionEffect.Play();
            explosionSound.Play();

            if (other.CompareTag("Player"))
            {
                if (TankManager.instance.tank == 0)
                {
                    playerHealth.ApplyDamage(damageTank1);
                }
                else if (TankManager.instance.tank == 1)
                {
                    playerHealth.ApplyDamage(damageTank2);
                }
                else if (TankManager.instance.tank == 2)
                {
                    playerHealth.ApplyDamage(damageTank2);

                }

                Destroy(gameObject, 0.3f);
            }
        }

    }

}
