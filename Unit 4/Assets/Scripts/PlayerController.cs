using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public bool hasPowerup;
    private float powerupStrength = 15.0f;
    public GameObject[] powerupIndicators;

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody component of the player
        playerRb = GetComponent<Rigidbody>();
        // Get the focal point
        focalPoint = GameObject.Find("Focal Point");


    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical input
        float forwardInput = Input.GetAxis("Vertical");

        // Move the player forward
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        // Move the player left and right

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            for (int i = 0; i < powerupIndicators.Length; i++)
            {
                powerupIndicators[i].gameObject.SetActive(true);
            }

        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        for (int i = 0; i < powerupIndicators.Length; i++)
        {
            powerupIndicators[i].gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            // Get the enemy rigidbody
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            // Get the direction from the player to the enemy
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;
            // Add force away from the player
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("Player collided with " + collision.gameObject + " with powerup set to " + hasPowerup);
        }
    }
}
