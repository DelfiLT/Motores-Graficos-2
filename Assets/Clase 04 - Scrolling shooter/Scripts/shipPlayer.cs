using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class shipPlayer : MonoBehaviour
{
    private float movX;
    private float movY;
    private float timer;

    public float timeToFire;
    public float playerSpeed;
    public float bulletForce;
    public float life = 100;
    public float maxHability;
    public float habSpeed;

    public Vector3 camForce;

    public GameObject bullet;
    public GameObject specialBullet;
    public Transform bulletSpawn;
    public Transform playerBody;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI hability;


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

        if(Input.GetMouseButton(1))
        {
            if (maxHability >= 100)
            {
                maxHability = 0;
                fireSpecialBullet();
            }
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

        lifeText.text = "HP: " + life.ToString("00");

        if (life == 0)
        {
            SceneManager.LoadScene("End");
        }

        if(maxHability <= 100)
        {
            maxHability += habSpeed * Time.deltaTime;
        }

        hability.text = "HAB: " + maxHability.ToString("00");
    }

    void fireBullet()
    {
        GameObject bulletClone = Instantiate(bullet, bulletSpawn.position, playerBody.rotation);

        Rigidbody bulletRbLeft = bulletClone.GetComponent<Rigidbody>();

        bulletRbLeft.AddRelativeForce((Vector3.up * bulletForce) + camForce, ForceMode.Impulse);

        Destroy(bulletClone, 4);
    }

    void fireSpecialBullet()
    {
        GameObject specialBulletClone = Instantiate(specialBullet, bulletSpawn.position, playerBody.rotation);

        Rigidbody SBRb = specialBulletClone.GetComponent<Rigidbody>();

        SBRb.AddRelativeForce((Vector3.up * bulletForce) + camForce, ForceMode.Impulse);

        Destroy(specialBulletClone, 4);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("enemyBullet"))
        {
            life = life - 10;
        }
    }
}
