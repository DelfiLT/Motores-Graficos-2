using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject[] maps;

    int chooseObstacle;
    public int zPos = 50;
    public int coins;

    public bool createSection = false;

    public float score;

    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI coinsUI;

    void Start()
    {
        coins = 0;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        scoreUI.text = "S " + score.ToString("F0");
        coinsUI.text = "COINS " + coins.ToString("F0");

        score += Time.deltaTime * 2f;  

        if(createSection == false)
        {
            createSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        chooseObstacle = Random.Range(0, 3);
        Instantiate(maps[chooseObstacle], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50;
        yield return new WaitForSeconds(3);
        createSection = false;
    }
}
