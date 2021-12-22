using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{

    [SerializeField]
    private Transform otherBlock;

    [HideInInspector]
    public float groundSize = 298f;

    private Transform player;

    private float offsetX = 10f;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }


    void Update()
    {

        if(player.position.x < transform.position.x - groundSize - offsetX)
        {

            transform.position = new Vector3(otherBlock.position.x - groundSize, transform.position.y, transform.position.z);


        }
      
    }
}
