using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class key : MonoBehaviour
{
    public bool hasKey;
    public GameObject pick;

    private void Start()
    {
        pick.SetActive(false);
        hasKey = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pick.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                hasKey = true;
                other.GetComponentInParent<player5>().life = other.GetComponentInParent<player5>().life + 20;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pick.SetActive(false);
        }
    }
}
