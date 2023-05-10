using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipPlayer : MonoBehaviour
{
    private float movX;
    private float movY;
    public float playerSpeed;

    private shoot shootScript;

    void Start()
    {
        shootScript = GameObject.FindGameObjectWithTag("shoot").GetComponent<shoot>();
    }


    void Update()
    {
        movX = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        movY = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;

        transform.Translate(movX, 0, movY);

        if(Input.GetMouseButton(0) && shootScript.canFire) 
        {
            shootScript.canFire = false;
            Instantiate(shootScript.bullet, shootScript.leftBullet.position, Quaternion.identity);
            Instantiate(shootScript.bullet, shootScript.rightBullet.position, Quaternion.identity);
        }
    }
}
