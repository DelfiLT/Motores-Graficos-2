using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float timer;

    void Update()
    {

        timer += Time.deltaTime;

        transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);

        if(timer > 5)
        {
            Destroy(gameObject);
        }
    }
}
