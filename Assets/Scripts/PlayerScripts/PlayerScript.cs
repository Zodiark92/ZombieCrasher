using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Vector3 tankSpeed;  
    public float x_speed=10f, z_speed=8f;

    [SerializeField]
    private float accelerationSpeed = 15f;

    [SerializeField]
    private float decelerationSpeed = 5f;

    private Rigidbody myBody;
    private AudioSource audioTank;

    private float rotationSpeed = 10f;
    private float maxAngle = 20f;

    [SerializeField]
    private float audioAcceleration = 1f, audioDeceleration = 0.3f, audioNormal = 0.6f;

    [SerializeField]
    private Animator reloadBar_Anim;

    [SerializeField]
    private Transform bulletPoint;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private ParticleSystem shootFX;

    [SerializeField]
    private Button shootBtn;

    [HideInInspector]
    public bool canShoot = true;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        audioTank = GetComponent<AudioSource>();

        shootBtn.onClick.AddListener(Shoot);
    }

    private void Start()
    {
        tankSpeed = new Vector3(-x_speed, 0f, 0f);

        audioTank.Play();
    }


    private void Update()
    {
        PlayerController();

        if (tankSpeed.z > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, maxAngle, 0), rotationSpeed * Time.deltaTime);
        }
        else if(tankSpeed.z < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,-maxAngle, 0), rotationSpeed * Time.deltaTime);

        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), rotationSpeed * Time.deltaTime);
        }

    }

    private void FixedUpdate()
    {
        myBody.MovePosition(myBody.position + tankSpeed * Time.deltaTime);
    }


    void PlayerController()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            Accelerate();

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            MoveNormal();

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            MoveLeft();

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            MoveStraight();

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            Decelerate();

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            MoveNormal();

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow))
            MoveRight();

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow))
            MoveStraight();

       
    }



    void MoveStraight()
    {
        tankSpeed = new Vector3(tankSpeed.x, 0, 0);

        
    }
   
    void MoveLeft()
    {
        tankSpeed = new Vector3(tankSpeed.x, tankSpeed.y, -z_speed / 2);
    }


    void MoveRight()
    {

        tankSpeed = new Vector3(tankSpeed.x, tankSpeed.y, z_speed / 2);
    }

    void MoveNormal()
    {
        tankSpeed = new Vector3(-x_speed, tankSpeed.y, tankSpeed.z);

        audioTank.volume = audioNormal;
    }


    void Accelerate()
    {
        tankSpeed = new Vector3(-accelerationSpeed, tankSpeed.y, tankSpeed.z);

        audioTank.volume = audioAcceleration;
    }

    void Decelerate() 
    {
        tankSpeed = new Vector3(-decelerationSpeed, tankSpeed.y, tankSpeed.z);

        audioTank.volume = audioDeceleration;
        audioTank.volume = audioDeceleration;
    }


  public void Shoot()
    {
        if (Time.timeScale != 0)
        {
            if (canShoot)
            {
                canShoot = false;
                Instantiate(bullet, bulletPoint.position, Quaternion.identity);
                shootFX.Play();
          
                reloadBar_Anim.SetTrigger("Shoot");

                if (TankManager.instance.tank == 2)
                    reloadBar_Anim.speed = 2f;
                
            }
        }
        
    }
    






}
