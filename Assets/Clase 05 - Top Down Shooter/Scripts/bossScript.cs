using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossScript : MonoBehaviour
{
    private Transform player;
    private float distance;

    public float life;
    public float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("pBody").GetComponent<Transform>();
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);

        if (distance < 10)
        {
            transform.LookAt(player.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        if (life <= 0)
        {
            SceneManager.LoadScene("End");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            life = life - 10;
            Destroy(other.gameObject);
        }
    }
}
