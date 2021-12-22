using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private GameObject[] obstaclePrefabs;

    [SerializeField]
    private Transform[] lanes;

    [SerializeField]
    private GameObject[] zombiePrefabs;

    [SerializeField]
    private GameObject helicupterPrefab;

    [SerializeField]
    private GameObject boxPrefab;

    [SerializeField]
    private Text scoreKilled_Text;

    [SerializeField]
    private Text scoreKilledGameOver_Text;

    [SerializeField]
    private Text scoreBoxGameOver_Text;

    [SerializeField]
    private Button shootBtn;

    public int scoreKilled;

    private float halfGroundSize;
    private float min_ObstacleDistance = 5f, max_ObstacleDistance = 10f;

    private Transform player;
    private int tank_Chosen;

    [SerializeField]
    private GameObject[] playerTank;

    [SerializeField]
    private GameObject gameOverPanel;

    private Animator gameOverPanelAnimation;

    [SerializeField]
    private GameObject UIHolder;

   
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

        player = GameObject.FindWithTag("Player").transform;
        halfGroundSize = GameObject.Find("RoadBlock").GetComponent<GroundScript>().groundSize / 2;
        gameOverPanelAnimation = gameOverPanel.GetComponent<Animator>();

    }

    private void Start()
    {
        scoreKilled = 0;
        scoreKilled_Text.text = scoreKilled.ToString();
       // gameOverPanel.SetActive(true);
        gameOverPanelAnimation.Play("Idle");
        tank_Chosen = TankManager.instance.tank;

        for (int i = 0; i < playerTank.Length; i++)
        {
            if (i == tank_Chosen)
            {
               playerTank[i].SetActive(true);
            }
            else
                playerTank[i].SetActive(false);
        }

        StartCoroutine("GenerateObstacle");
    }


    IEnumerator GenerateObstacle()
    {
        float timer = Random.Range(min_ObstacleDistance, max_ObstacleDistance) / player.GetComponent<PlayerScript>().x_speed;

        yield return new WaitForSeconds(timer);


        AddObstacles(player.position.x - halfGroundSize);

        StartCoroutine("GenerateObstacle");


    }

    void AddObstacles(float x_pos)
    {
        int r = Random.Range(0, 11);
        int laneNumber = Random.Range(0, lanes.Length);

        if(0 <= r && r < 7)
        {
            
            InstantiateObstacle(new Vector3(x_pos, lanes[laneNumber].position.y-0.15f, lanes[laneNumber].position.z));

            int zombieLane = 0;

            if (laneNumber == 0)
            {
                if (Random.Range(0, 2) == 0)
                    zombieLane = 1;
                else
                    zombieLane = 2;
            }
            else if (laneNumber == 1)
            {
                if (Random.Range(0, 2) == 0)
                    zombieLane = 0;
                else
                    zombieLane = 2;
            }
            else  //LANE NUMBER == 2
            {
                if (Random.Range(0, 2) == 0)
                    zombieLane = 0;
                else
                    zombieLane = 1;
            }

            InstantiateZombie(new Vector3(x_pos, lanes[zombieLane].position.y+0.01f, lanes[zombieLane].position.z));

        }
        if (r == 7)
        {

          Instantiate(helicupterPrefab, new Vector3(x_pos, lanes[laneNumber].transform.position.y + 2f, lanes[laneNumber].transform.position.z),Quaternion.Euler(0,270,0));

        }

        if (r == 8)
        {
            Instantiate(boxPrefab, new Vector3(x_pos, lanes[laneNumber].transform.position.y -0.15f, lanes[laneNumber].transform.position.z), Quaternion.identity);
        }

    }

    void InstantiateObstacle(Vector3 pos)
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);

       GameObject obstacleCreated =  Instantiate(obstaclePrefabs[obstacleIndex], pos, Quaternion.Euler(0, Random.Range(0, 360), 0));

        if(obstacleIndex==6)
        {
            if(Random.Range(0,2)==0)
            obstacleCreated.transform.rotation = Quaternion.Euler(0, Random.Range(260, 300), 0);
            else
                obstacleCreated.transform.rotation = Quaternion.Euler(0, Random.Range(60, 100), 0);

        }


    }

    void InstantiateZombie(Vector3 pos)
    {
        int count = Random.Range(1, 5);

        for(int i=0; i < count+1; i++)
        {
            Vector3 shift = new Vector3(Random.Range(-0.5f, 0.5f) * i, 0f, Random.Range(-0.5f, 0.5f));

            Instantiate(zombiePrefabs[Random.Range(0,zombiePrefabs.Length)], pos+shift*i, Quaternion.identity);

        }

    }

    public void addScoreKilled()
    {
        scoreKilled++;
        scoreKilled_Text.text = scoreKilled.ToString();

    }


    public void GameOver()
    {
        UIHolder.SetActive(false);
        gameOverPanel.SetActive(true);
        shootBtn.gameObject.SetActive(false);
        gameOverPanelAnimation.Play("FadeIn");


        TankManager.instance.currentKilled = scoreKilled;
        TankManager.instance.currentPoints = player.gameObject.GetComponent<PlayerHealth>().Score();
        scoreKilledGameOver_Text.text = scoreKilled.ToString();
        scoreBoxGameOver_Text.text = player.gameObject.GetComponent<PlayerHealth>().Score().ToString();

        Time.timeScale = 0f;
    }
}
