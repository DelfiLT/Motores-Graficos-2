using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class key : MonoBehaviour
{
    public GameObject pick;
    public GameObject particlePfab;
    private player5 playerScript;

    private void Start()
    {
        pick.SetActive(false);
        playerScript = GameObject.FindGameObjectWithTag("pBody").GetComponent<player5>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("pBody"))
        {
            pick.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                playerScript.hasKey = true;
                other.GetComponentInParent<player5>().life = other.GetComponentInParent<player5>().life + 20;
                GameObject particleVFX = Instantiate(particlePfab, transform.position, Quaternion.identity);
                Destroy(particleVFX, 2f);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("pBody"))
        {
            pick.SetActive(false);
        }
    }
}
