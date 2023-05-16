using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMov : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("end"))
        {
            speed = 0;
        }
    }
}
