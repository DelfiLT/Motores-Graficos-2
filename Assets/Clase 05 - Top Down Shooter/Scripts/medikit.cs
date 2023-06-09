using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class medikit : MonoBehaviour
{
    public GameObject pick;
    public GameObject particlePfab;

    private void Start()
    {
        pick.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("pBody"))
        {
            pick.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
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
