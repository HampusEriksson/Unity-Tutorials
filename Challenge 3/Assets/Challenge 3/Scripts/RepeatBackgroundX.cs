using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    private float width;

    private Vector3 respawnPos ;

    private void Start()
    {
        width = GetComponent<BoxCollider>().size.x; // Set repeat width to half of the background
        respawnPos = new Vector3(width, 9.5f, 4);
    }

    private void Update()
    {
        // If background moves left by its repeat width, move it back to start position
        if (transform.position.x < -width)
        {
            transform.position = respawnPos;
        }
    }

 
}


