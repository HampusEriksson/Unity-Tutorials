using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Speed of camera movement

    void Update()
    {
        // Get the input for movement in the horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.position = new Vector3(transform.position.x + horizontalInput * moveSpeed * Time.deltaTime, 30, transform.position.z + verticalInput * moveSpeed * Time.deltaTime);


    }
}
