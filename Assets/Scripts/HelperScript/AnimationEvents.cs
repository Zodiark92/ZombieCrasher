using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvents : MonoBehaviour
{
    private PlayerScript playerScript;
    private Animator reloadSliderAnim;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name=="MainMenu")
                return;


        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        reloadSliderAnim = GameObject.Find("ReloadBar").GetComponent<Animator>();
    }


    public void CanShoot()
    {   
            playerScript.canShoot = true;          
    }


    public void CameraAnimation()
    {
        SceneManager.LoadScene("Gameplay");

    }


}
