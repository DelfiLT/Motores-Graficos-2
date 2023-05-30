using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class medikit : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("pick");
                other.GetComponentInParent<player5>().life = other.GetComponentInParent<player5>().life + 20;
                Destroy(this.gameObject);
            }
        }
    }
}
