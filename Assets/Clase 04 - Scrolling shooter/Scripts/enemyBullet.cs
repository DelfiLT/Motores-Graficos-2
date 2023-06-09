using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float speed;
    public float timer;
    public float camSpeed;
    private Transform player;
    private Vector3 playerPos;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerPos = player.position;
        Vector3 distance = playerPos - transform.position;
        rb.AddForce(new Vector2(distance.x, distance.y).normalized * speed);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            Destroy(gameObject);
        }

        if (transform.position.z >= 470f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
