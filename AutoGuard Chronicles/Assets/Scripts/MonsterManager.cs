using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    private int hp;
    private float speed;

    private GameManager gameManager;

    private Vector3 target;

    // List of the path stored in (x,0,z) coordinates
    private List<Vector3> path = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        hp = 100 * gameManager.getLevel();
        speed = 1 + 0.25f * (gameManager.getLevel() - 1);
        setupPath();
        target = path[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the monster towards the target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // If the monster is close enough to the target, set the next target
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            // If the monster is at the end of the path, destroy it
            if (path.IndexOf(target) == path.Count - 1)
            {
                Destroy(gameObject);
            }
            else
            {
                target = path[path.IndexOf(target) + 1];
            }
        }
        
    }

    // Setup the path
    void setupPath()
    {
       path.Add(new Vector3(0, 1, 7));
        path.Add(new Vector3(1, 1, 7));
        path.Add(new Vector3(1, 1, 1));
        path.Add(new Vector3(3, 1, 1));
        path.Add(new Vector3(3, 1, 7));
        path.Add(new Vector3(5, 1, 7));
        path.Add(new Vector3(5, 1, 1));
        path.Add(new Vector3(6, 1, 1));
    }
}
