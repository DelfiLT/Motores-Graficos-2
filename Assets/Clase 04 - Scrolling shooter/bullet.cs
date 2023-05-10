using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public float force;
    public float timer;
    private Rigidbody rb;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        rb.velocity = new Vector3(direction.x, direction.y, direction.z).normalized * force;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }

}
