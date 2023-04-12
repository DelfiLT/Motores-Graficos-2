using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    public int offsetZ = -44;


    void Update()
    {
        transform.position -= new Vector3(0, 0, 6 * Time.deltaTime);
        if (transform.position.z <= offsetZ)
        {
            transform.position = new Vector3(0, transform.position.y, 44);
        }
    }
}


