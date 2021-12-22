using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float speedBullet = 5000f;

    private Rigidbody myBody;
    private AudioSource shootAudio;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        shootAudio = GetComponent<AudioSource>();

        myBody.AddForce(-speedBullet * transform.right);

        Destroy(gameObject, 3f);
        
    }

    
}
