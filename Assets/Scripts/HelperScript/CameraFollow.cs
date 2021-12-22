using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private float height = 1.61f;

    [SerializeField]
    private float rotation_damping = 2f;

    private float height_damping = 0.25f;

    private float currentHeight, wantedHeight;

    [SerializeField]
    private float distance = 6f;

    private Vector3 currentPosition, wantedPosition;

    private float currentAngle, wantedAngle;

    private Transform player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;

       
    }

    private void Start()
    {
        currentPosition = transform.position;

        currentAngle = transform.eulerAngles.y;
        wantedAngle = transform.eulerAngles.y - 90f;

      
    }


    private void LateUpdate()
    {

        currentAngle = transform.eulerAngles.y;
        wantedAngle = player.eulerAngles.y - 90f;

        currentHeight = transform.position.y;
        wantedHeight = player.position.y + height;

        currentAngle = Mathf.LerpAngle(currentAngle, wantedAngle, rotation_damping * Time.deltaTime);

        Quaternion current_Angle = Quaternion.Euler(transform.eulerAngles.x, currentAngle, transform.eulerAngles.z);

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, height_damping * Time.deltaTime);

        transform.rotation = current_Angle;

        transform.position = player.position;
        transform.position -= Vector3.left * distance;

        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
        



    }




}
