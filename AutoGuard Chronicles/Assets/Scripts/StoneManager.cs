using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneManager : MonoBehaviour
{
        private GameObject content;
            private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void OnMouseDown()
    {
        destroyContent();
        // Create the tower on the stone (the y value needs to be above the stone )
               content = Instantiate(gameManager.getActiveTower(), new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z), Quaternion.identity);


    }

    // Destroy the content of the tile
    void destroyContent()
    {
        if (content != null)
        {
            Destroy(content);
        }
    }
}
