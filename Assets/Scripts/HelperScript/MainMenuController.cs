using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{

    [SerializeField]
    private GameObject[] playerTank;

    [SerializeField]
    private GameObject killed_Bar, Point_Bar;

    [SerializeField]
    private GameObject x_icon;

    [SerializeField]
    private GameObject playButton;

    private Animator cameraAnim;

    private int tankNumber=0;

    public static MainMenuController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }


    private void Start()
    {
        cameraAnim = Camera.main.GetComponent<Animator>();

        playerTank[0].SetActive(true);
        playerTank[1].SetActive(false);
        playerTank[2].SetActive(false);
        playButton.SetActive(true);

        killed_Bar.gameObject.SetActive(false);
        Point_Bar.gameObject.SetActive(false);
        x_icon.gameObject.SetActive(false);

        tankNumber = 0;
    }




    public void ChooseTank()
    {
        tankNumber++;

        if (tankNumber == 3)
            tankNumber = 0;

        if (tankNumber == 0)
        {
            playerTank[0].SetActive(true);
            playerTank[1].SetActive(false);
            playerTank[2].SetActive(false);
            playButton.SetActive(true);

            killed_Bar.gameObject.SetActive(false);
            Point_Bar.gameObject.SetActive(false);
            x_icon.gameObject.SetActive(false);

        }
        else if(tankNumber == 1)
        {
            playerTank[0].SetActive(false);
            playerTank[1].SetActive(true);
            playerTank[2].SetActive(false);

            if (!TankManager.instance.condition2)
            {
                killed_Bar.gameObject.SetActive(true);
                Point_Bar.gameObject.SetActive(true);
                x_icon.gameObject.SetActive(true);
                playButton.SetActive(false);


                killed_Bar.GetComponentInChildren<Text>().text = "100";
                Point_Bar.GetComponentInChildren<Text>().text = "12";

            }
            else
            {
                killed_Bar.gameObject.SetActive(false);
                Point_Bar.gameObject.SetActive(false);
                x_icon.gameObject.SetActive(false);
                playButton.SetActive(true);


            }


        }
        else if (tankNumber == 2)
        {
            playerTank[0].SetActive(false);
            playerTank[1].SetActive(false);
            playerTank[2].SetActive(true);


            if (!TankManager.instance.condition3)
            {
                killed_Bar.gameObject.SetActive(true);
                Point_Bar.gameObject.SetActive(true);
                x_icon.gameObject.SetActive(true);
                playButton.SetActive(false);


                killed_Bar.GetComponentInChildren<Text>().text = "200";
                Point_Bar.GetComponentInChildren<Text>().text = "25";

            }
            else
            {
                killed_Bar.gameObject.SetActive(false);
                Point_Bar.gameObject.SetActive(false);
                x_icon.gameObject.SetActive(false);
                playButton.SetActive(true);

            }

        }

    }


   public void PlayGame()
    {
        TankManager.instance.tank = tankNumber;
        cameraAnim.Play("RotationIntro");
    }




}
