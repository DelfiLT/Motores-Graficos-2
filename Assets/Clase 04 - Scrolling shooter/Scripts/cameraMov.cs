using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMov : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);    

        if(transform.position.z >= 470f)
        {
            speed = 0;
        }
    }
}
