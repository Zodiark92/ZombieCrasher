using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    private Transform player;

    [SerializeField]
    private Transform[] missiles;

    [SerializeField]
    private GameObject missilePrefab;

    private AudioSource shootSound;

    [SerializeField]
    private int countMissiles;
   
    private float distance = 40f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        shootSound = GetComponent<AudioSource>();
      
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < distance)
        {       
               AttackPlayer();         
        }          
   
    }


    void AttackPlayer()
    {
        if (countMissiles == 0)
            return;
        else
        {  
            for(int i = countMissiles; i > 0; i--) { 
            
                if(gameObject.CompareTag("Helicopter"))
                Instantiate(missilePrefab, missiles[i-1].transform.position-new Vector3(0,1.5f,0), Quaternion.identity);
                else
                    Instantiate(missilePrefab, missiles[i - 1].transform.position, Quaternion.identity);

                shootSound.Play();
                missiles[i - 1].gameObject.SetActive(false);

                countMissiles--;
               
               
            }

        }
        
    }




}
