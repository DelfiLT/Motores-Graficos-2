using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pBody : MonoBehaviour
{
    private player5 playerScript;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("pBody").GetComponent<player5>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            playerScript.life = playerScript.life - 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemyBullet"))
        {
            playerScript.life = playerScript.life - 10;
            Destroy(other.gameObject);
        }
    }
}
