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

        // Calculate the translation based on the input and time
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput) * moveSpeed * Time.deltaTime;

        // Get the current rotation of the camera
        Quaternion currentRotation = transform.rotation;

        // Zero out the Y-axis rotation to keep the camera movement horizontal
        currentRotation.x = 0;
        currentRotation.z = 0;

        // Apply the translation to the camera's position while keeping the Y-axis rotation unchanged
        transform.Translate(currentRotation * movement);
    }
}
