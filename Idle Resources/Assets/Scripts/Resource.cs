using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{

    private int amount;
    GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager");

        amount = UnityEngine.Random.Range(5, 10); // Initialize the variable within Start()

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool harvest()
    {
        if (amount > 0)
        {
            amount--;
            if (amount == 0)
            {
                gameManager.GetComponent<GameManager>().spawnedResources--;
                Destroy(gameObject);
            }
            return true;
        }
        else
        {
            
            return false;
        }
    }
}
