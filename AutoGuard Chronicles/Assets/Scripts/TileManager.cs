using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    private GameObject content;
    private GameManager gameManager;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Do something when the tile is clicked
    void OnMouseDown()
    {
       content = Instantiate(gameManager.getActiveTower(), transform.position, Quaternion.identity);
    }
}
