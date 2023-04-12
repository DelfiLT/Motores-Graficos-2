using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    void Update()
    {
     
        if(transform.position.x == 0 || transform.position.x == -3f)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.Translate(0, 0, 3f);
            }
        }
        if (transform.position.x == 0 || transform.position.x == 3f)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.Translate(0, 0, -3f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
