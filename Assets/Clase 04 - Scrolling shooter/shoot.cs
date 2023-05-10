using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    private Camera mainCam;

    private Vector3 mousePos;

    private float timer;
    public float timeToFire;

    public bool canFire;

    public GameObject bullet;
    public Transform rightBullet;
    public Transform leftBullet;

    void Start()
    {
        canFire = true;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        float rotationY = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
    
        transform.rotation = Quaternion.Euler(0, rotationY, 0);

        if(!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeToFire)
            {
                canFire = true;
                timer = 0;
            }
        }
    }

}

