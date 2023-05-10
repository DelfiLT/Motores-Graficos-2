using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Transform rightBullet;
    public Transform leftBullet;
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
        GameObject bulletLeft = Instantiate(bullet, leftBullet.position, playerBody.rotation);
        GameObject bulletRight = Instantiate(bullet, rightBullet.position, playerBody.rotation);

        Rigidbody bulletRbLeft = bulletLeft.GetComponent<Rigidbody>();
        Rigidbody bulletRbRight = bulletRight.GetComponent<Rigidbody>();

        bulletRbLeft.AddRelativeForce((Vector3.up * bulletForce) + camForce, ForceMode.Impulse);
        bulletRbRight.AddRelativeForce((Vector3.up * bulletForce) + camForce, ForceMode.Impulse);

        Destroy(bulletLeft, 4);
        Destroy(bulletRight, 4);
    }
}
