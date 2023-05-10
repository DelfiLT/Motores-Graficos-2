using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 distance = mousePos - transform.position;

        float rotationY = Mathf.Atan2(distance.x, distance.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, rotationY, 0);

        //transform.LookAt(new Vector3( mousePos.x, 0, mousePos.z));
    }

}

