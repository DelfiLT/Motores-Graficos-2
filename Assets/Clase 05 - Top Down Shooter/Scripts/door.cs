using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    private Animator doorAnim;

    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            doorAnim.SetBool("open", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("closeDoor", 3f);
        }
    }

    void closeDoor()
    {
        doorAnim.SetBool("open", false);
    }

}
