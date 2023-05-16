using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public float speed;
    public float camSpeed;
    public float life;

    private Transform player;
    public GameObject particlePfab;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * camSpeed, Space.World);

        if (transform.position.z >= 470f)
        {
            Destroy(gameObject);
        }

        transform.LookAt(player.transform.position);

        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (life == 0)
        {
            GameObject particleVFX = Instantiate(particlePfab, transform.position, Quaternion.identity);
            Destroy(particleVFX, 2f);
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("bullet"))
        {
            life = life - 10;
        }
        if(other.gameObject.CompareTag("specialBullet"))
        {
            life = life - 30;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameObject particleVFX = Instantiate(particlePfab, transform.position, Quaternion.identity);
            Destroy(particleVFX, 2f);
            Destroy(this.gameObject);
        }
    }
}
