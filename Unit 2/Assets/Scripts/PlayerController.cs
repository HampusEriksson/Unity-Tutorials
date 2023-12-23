using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontalInput;
    private float speed = 40.0f;
    private float xRange = 22.0f;

    public GameObject projectilePrefab;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Keep the player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");

        // Move the player
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);


        // Launch a projectile from the player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position + new Vector3(0, 3, 0), projectilePrefab.transform.rotation);
        }


    }
}
