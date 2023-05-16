using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawn;
    private Camera mainCam;
    private GameObject boss;
    public TextMeshProUGUI lifeText;

    int chooseEnemy;

    public float timer;
    public float timeBetweenSpawns;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        boss = GameObject.FindGameObjectWithTag("boss");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            if(mainCam.transform.position.z <= 460f)
            {
                GenerateObstacle();
                boss.SetActive(false);
                lifeText.text = "";

            } else
            {
                boss.SetActive(true);
                lifeText.text = "FINAL BOSS " + boss.GetComponent<boss>().life.ToString("00");
            }
        }

        if(boss.GetComponent<boss>().life == 0)
        {
            Invoke("gameOver", 2f);
        }
    }

    void GenerateObstacle()
    {
        chooseEnemy = Random.Range(0, 2);
        if (chooseEnemy == 0) { Instantiate(enemies[0], spawn[Random.Range(0,3)].position, Quaternion.identity); }
        if (chooseEnemy == 1) { Instantiate(enemies[1], spawn[Random.Range(0, 3)].position, Quaternion.identity); }
    }

    private void gameOver()
    {
        SceneManager.LoadScene("End");
    }
}
