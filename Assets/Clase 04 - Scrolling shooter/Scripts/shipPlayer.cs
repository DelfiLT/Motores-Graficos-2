using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shipPlayer : MonoBehaviour
{
    private float movX;
    private float movY;
    private float timer;

    public float timeToFire;
    public float playerSpeed;
    public float bulletForce;

    public Vector3 camForce;

    public GameObject bullet;
    public Transform bulletSpawn;
    public Transform playerBody;


    public bool canFire;

    void Start()
    {
        canFire = true;
    }


    void Update()
    {
        movX = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        movY = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;

        transform.Translate(movX, 0, movY);

        if(Input.GetMouseButton(0) && canFire) 
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

    void fireBullet()
    {
        GameObject bulletClone = Instantiate(bullet, bulletSpawn.position, playerBody.rotation);

        Rigidbody bulletRbLeft = bulletClone.GetComponent<Rigidbody>();

        bulletRbLeft.AddRelativeForce((Vector3.up * bulletForce) + camForce, ForceMode.Impulse);

        Destroy(bulletClone, 4);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("enemyBullet"));
        {
            //SceneManager.LoadScene("Game");
        }
    }
}
