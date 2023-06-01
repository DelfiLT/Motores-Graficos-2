using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class topdownenemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    private Transform player;

    private float distance;
    private float timer;

    public float speed;
    public float bulletForce;
    public float timeToFire;

    public bool canFire;

    void Start()
    {
        canFire = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);

        if (distance < 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        if(distance < 10)
        {
            if (canFire)
            {
                Vector3 targetPostition = new Vector3(player.position.x, this.transform.position.y, player.position.z);
                this.transform.LookAt(targetPostition);
                canFire = false;
                fireBullet();

            }

            if (!canFire)
            {
                timer += Time.deltaTime;
                if (timer > timeToFire)
                {
                    canFire = true;
                    timer = 0;
                }
            }
        }
        
    }
    void fireBullet()
    {
        GameObject bulletClone = Instantiate(bullet, bulletSpawn.position, this.transform.rotation);

        Rigidbody bulletRb = bulletClone.GetComponent<Rigidbody>();

        bulletRb.AddRelativeForce((Vector3.forward * bulletForce), ForceMode.Impulse);

        Destroy(bulletClone, 4);
    }
}
