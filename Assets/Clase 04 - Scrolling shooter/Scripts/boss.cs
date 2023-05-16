using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class boss : MonoBehaviour
{
    public float timeBetweenFire;
    public float life;
    private float timer;

    public GameObject bullet;
    public GameObject particlePfab;
    public Transform bulletTransform;

    public bool canFire;

    void Start()
    {
        canFire = true;
    }

    void Update()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFire)
            {
                canFire = true;
                timer = 0;
            }
        }
        else
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
            life = life - 100;
        }
    }
}
