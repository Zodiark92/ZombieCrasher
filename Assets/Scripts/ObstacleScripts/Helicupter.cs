using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicupter : MonoBehaviour
{
    private Rigidbody myBody;

    [SerializeField]
    private float speed=10f;


    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        myBody.velocity = new Vector3(speed, 0, 0);

    }
}
