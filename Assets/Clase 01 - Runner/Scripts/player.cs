using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float speed;
    public float speedMultiplier;

    void Update()
    {
        speedMultiplier += Time.deltaTime * 0.2f;

        transform.Translate(Vector3.forward * Time.deltaTime * (speed + speedMultiplier), Space.World);

        if (transform.position.x == 0 || transform.position.x == -2.5f)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.Translate(2.5f, 0, 0);
            }
        }
        if (transform.position.x == 0 || transform.position.x == 2.5f)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.Translate(-2.5f, 0, 0);
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
