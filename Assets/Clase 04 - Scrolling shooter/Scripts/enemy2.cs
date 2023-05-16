using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public float speed;
    public float camSpeed;
    public float timeBetweenFire;
    public float life;
    private float timer;

    public GameObject bullet;
    public GameObject particlePfab;
    public Transform bulletTransform;
    private Transform player;

    public bool canFire;

    void Start()
    {
        canFire = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * camSpeed, Space.World);
        transform.LookAt(player.transform.position);

        if (transform.position.z >= 470f)
        {
            Destroy(gameObject);
        }

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFire)
            {
                canFire = true;
                timer = 0;
            }
        } else
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }

        if (life == 0)
        {
            GameObject particleVFX = Instantiate(particlePfab, transform.position, Quaternion.identity);
            Destroy(particleVFX, 2f);
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            life = life - 10;
        }
        if (other.gameObject.CompareTag("specialBullet"))
        {
            life = life - 50;
        }
    }
}
