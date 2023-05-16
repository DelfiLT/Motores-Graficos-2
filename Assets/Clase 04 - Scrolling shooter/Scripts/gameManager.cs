using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawn;

    int chooseEnemy;

    public float timer;
    public float timeBetweenSpawns;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            GenerateObstacle();
        }
    }

    void GenerateObstacle()
    {
        chooseEnemy = Random.Range(0, 2);
        if (chooseEnemy == 0) { Instantiate(enemies[0], spawn[Random.Range(0,3)].position, Quaternion.identity); }
        if (chooseEnemy == 1) { Instantiate(enemies[1], spawn[Random.Range(0, 3)].position, Quaternion.identity); }
    }
}
