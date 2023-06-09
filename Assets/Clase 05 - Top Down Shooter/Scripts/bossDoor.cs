using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDoor : MonoBehaviour
{
    private Animator doorAnim;
    private player5 playerScript;
    public GameObject open;

    void Start()
    {
        open.SetActive(false);
        doorAnim = GetComponent<Animator>();
        playerScript = GameObject.FindGameObjectWithTag("pBody").GetComponent<player5>();
    }

    private void Update()
    {
        if(playerScript.hasKey)
        {
            open.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pBody") && playerScript.hasKey)
        {
            doorAnim.SetBool("open", true);
        }
        else
        {
            open.SetActive(true);
        }
    }

}
