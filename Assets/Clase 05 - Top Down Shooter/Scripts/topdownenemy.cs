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

    public float life;
    public float speed;
    public float bulletForce;
    public float timeToFire;

    public bool canFire;

    void Start()
    {
        canFire = false;
        player = GameObject.FindGameObjectWithTag("pBody").GetComponent<Transform>();
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);

        if (distance < 7)
        {
            transform.LookAt(player.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            if (canFire)
            {
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

        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    void fireBullet()
    {
        GameObject bulletClone = Instantiate(bullet, bulletSpawn.position, this.transform.rotation);

        Rigidbody bulletRb = bulletClone.GetComponent<Rigidbody>();

        bulletRb.AddRelativeForce((Vector3.forward * bulletForce), ForceMode.Impulse);

        Destroy(bulletClone, 4);
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
