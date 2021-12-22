using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject UIHolder;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private Button shootBtn;

    private int score_Killed;
    private PlayerHealth playerHealth;

    private void Start()
    {
        Time.timeScale = 1f;

        UIHolder.SetActive(true);
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        shootBtn.gameObject.SetActive(true);
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();

    }

    public void PauseGame()
    {
        shootBtn.gameObject.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0f;

    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        shootBtn.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;

        score_Killed = GameManager.instance.scoreKilled;
        TankManager.instance.currentKilled = score_Killed;
        TankManager.instance.currentPoints = playerHealth.Score();
        SceneManager.LoadScene("MainMenu");

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Gameplay");

    }
}
