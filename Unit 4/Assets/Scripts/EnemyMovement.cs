using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody component of the enemy
        enemyRb = GetComponent<Rigidbody>();
        // Get the player
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        // Get the direction from the enemy to the player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        // Move the enemy towards the player
        enemyRb.AddForce(lookDirection * speed);

        // If the enemy falls off the map, destroy it
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

    }
}
