using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player5 : MonoBehaviour
{
    private float movX;
    private float movY;
    private float timer;

    public float rotationSpeed;
    public float timeToFire;
    public float playerSpeed;
    public float bulletForce;
    public float life = 100;

    public GameObject bullet;
    public Transform bulletSpawn;
    public Transform playerBody;
    private Camera mainCam;
    //public TextMeshProUGUI lifeText;

    public bool canFire;

    void Start()
    {
        mainCam = Camera.main;
        canFire = true;
    }


    void Update()
    {
        movX = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        movY = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;

        transform.Translate(movX, 0, movY);

        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Vector3 mousePos = new Vector3(hit.point.x, playerBody.position.y, hit.point.z);
            Vector3 direction = mousePos - playerBody.position;

            if(direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction);
                playerBody.rotation = Quaternion.RotateTowards(playerBody.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }

        if (Input.GetMouseButton(0) && canFire)
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

        //lifeText.text = "HP: " + life.ToString("00");

        if (life == 0)
        {
            SceneManager.LoadScene("End");
        }
    }

    void fireBullet()
    {
        GameObject bulletClone = Instantiate(bullet, bulletSpawn.position, playerBody.rotation);

        Rigidbody bulletRbLeft = bulletClone.GetComponent<Rigidbody>();

        bulletRbLeft.AddRelativeForce((Vector3.forward * bulletForce), ForceMode.Impulse);

        Destroy(bulletClone, 4);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("enemyBullet"))
        {
            life = life - 10;
        }
    }

}

