using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    private Transform player;
    private float offset = 5f;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }


    private void Update()
    {
        if (player.position.x < transform.position.x - offset)
        {
             Destroy(gameObject);        
        }
    }




}
