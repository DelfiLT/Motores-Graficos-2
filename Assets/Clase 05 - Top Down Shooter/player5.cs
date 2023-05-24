using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player5 : MonoBehaviour
{
    public float velocity;
    public Vector3 mouse2D;

    void Start()
    {
        
    }

    void Update()
    {
        float movementX = Input.GetAxis("Horizontal") * velocity * Time.deltaTime;
        float movementZ = Input.GetAxis("Vertical") * velocity * Time.deltaTime;

        transform.Translate(movementX, 0, movementZ);

        mouse2D = Camera.main.ScreenToWorldPoint(Input.mousePosition);



        transform.LookAt(mouse2D);
    }
}
