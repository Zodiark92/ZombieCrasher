using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotorRotation : MonoBehaviour
{
    private float rotationSpeed = 1000f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);


    }
}
