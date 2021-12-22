using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPoint : MonoBehaviour
{
    [SerializeField]
    private int healthTank1, healthTank2, healthTank3;

  
    private int tankNumber;

    private void Start()
    {
        tankNumber = TankManager.instance.tank;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            if (tankNumber == 0)
            {
                other.gameObject.GetComponentInParent<PlayerHealth>().AddHealth(healthTank1);
            }
            else if (tankNumber == 1)
            {
                other.gameObject.GetComponentInParent<PlayerHealth>().AddHealth(healthTank2);
            }
            else if (tankNumber == 2)
            {
                other.gameObject.GetComponentInParent<PlayerHealth>().AddHealth(healthTank3);

            }

            other.gameObject.GetComponentInParent<PlayerHealth>().AddScore();        
            Destroy(gameObject, 0.1f);

        }
            
    }

    

}
