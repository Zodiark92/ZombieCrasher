using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankManager : MonoBehaviour
{
    public static TankManager instance;

    [HideInInspector]
    public int tank;

    private int killed_Condition2 = 100, killed_condition3 = 200;
    private int points_Condition2 = 12, points_condition3 = 25;

    public int currentKilled, currentPoints;
    public bool condition2, condition3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        if (currentKilled >= killed_Condition2 && currentPoints >= points_Condition2)
            condition2 = true;

        if (currentKilled >= killed_condition3 && currentPoints >= points_condition3)
            condition3 = true;


    }

        
        
}