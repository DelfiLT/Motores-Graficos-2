using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public float camSpeed;
    public float speed;
    public float timeBetweenFire;
    private float timer;

    public GameObject bullet;
    public Transform bulletTransform;

    public bool canFire;

    void Start()
    {
        canFire = true;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * camSpeed, Space.World);

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
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
