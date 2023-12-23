using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool canSpawn = true;
    public float cooldownTime = 5.0f; // Set the cooldown time here

    void Update()
    {
        // Check if the player can spawn and if spacebar is pressed
        if (canSpawn && Input.GetKeyDown(KeyCode.Space))
        {
            // Spawn the dog
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            // Start the cooldown timer
            StartCoroutine(StartCooldown());
        }
    }

    IEnumerator StartCooldown()
    {
        // Disable spawning
        canSpawn = false;

        // Wait for the cooldown time
        yield return new WaitForSeconds(cooldownTime);

        // Enable spawning again after cooldown
        canSpawn = true;
    }
}
