using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    int chooseObstacle;

    public float timer;
    public float timeBetweenSpawn;
    public float speedMultiplier;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > timeBetweenSpawn)
        {
            timer = 0;
            GenerateObstacle();
        }        
    }

    void GenerateObstacle()
    {
        chooseObstacle = Random.Range(0, 2);
        if(chooseObstacle == 0) { Instantiate(enemy1); }
        if(chooseObstacle == 1) { Instantiate(enemy2); }
        if(chooseObstacle == 2) { Instantiate(enemy3); }
    }
}
