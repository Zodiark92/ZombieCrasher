using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private int playerHealth = 100;
    private int maxHealth = 100;


    [SerializeField]
    private Slider healthBar;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private AudioSource pointAudio;

    private int score;


    void Start()
    {
        playerHealth = 100;
        score = 0;
        scoreText.text = score.ToString();
        
    }

    private void Update()
    {
        healthBar.value = playerHealth;
        
    }


    public void ApplyDamage(int damageAmount)
    {
        playerHealth -= damageAmount;

        if (playerHealth < 0)
        {
            playerHealth = 0;

            GameManager.instance.GameOver();

        }
          
    }

    public void AddHealth(int amount)
    {
        playerHealth += amount;

        if (playerHealth >= maxHealth)
            playerHealth = maxHealth;

    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        pointAudio.Play();

    }

    public int Score()
    {
        return score;
    }

}
