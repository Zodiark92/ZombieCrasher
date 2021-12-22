using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    private float speedZombie = 5f;

    [SerializeField]
    private ParticleSystem bloodEffect;

    private Animator animModel;
    private Rigidbody myBody;
    private AudioSource zombieSmashAudio;

    private bool isAlive;


    void Start()
    {
        animModel = GetComponentInChildren<Animator>();
        myBody = GetComponent<Rigidbody>();
        zombieSmashAudio = GetComponent<AudioSource>();

        isAlive = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            myBody.velocity = new Vector3(speedZombie, 0, 0);

        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Box"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            isAlive = false;
            myBody.velocity = Vector3.zero;
            bloodEffect.Play();
            animModel.enabled = false;
            zombieSmashAudio.Play();

            if (other.gameObject.CompareTag("Bullet"))
            {
              //  Destroy(other.gameObject);
                Destroy(gameObject,0.4f);

            }

            if (other.gameObject.CompareTag("Obstacle"))
                myBody.velocity = Vector3.zero;


            GameManager.instance.addScoreKilled();

        }


        //BULLET

    }



}
