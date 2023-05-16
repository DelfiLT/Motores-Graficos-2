using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misil : MonoBehaviour
{
    public float speed;
    public float timer;
    private Transform player;
    public GameObject particlePfab;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.LookAt(player.transform.position);

        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject particleVFX = Instantiate(particlePfab, transform.position, Quaternion.identity);
            Destroy(particleVFX, 2f);
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet") || other.gameObject.CompareTag("specialBullet"))
        {
            GameObject particleVFX = Instantiate(particlePfab, transform.position, Quaternion.identity);
            Destroy(particleVFX, 2f);
            Destroy(this.gameObject);
        }
    }
}
