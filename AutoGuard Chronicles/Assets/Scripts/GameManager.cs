using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject tile;
    private int batin = 20;

    // List of possible towers
    public GameObject[] towers;
    private int activeTower = 0;

    // ActiveTowerText
    public GameObject activeTowerText;

    private int level = 1;

    private List<List<char>> grid;

    public GameObject stone;

    public GameObject monster;



    // Start is called before the first frame update
    void Start()
    {
        setupGrid();

        // Loop through the grid and create the tiles
        for (int x = 0; x < grid.Count; x++)
        {
            for (int z = 0; z < grid[x].Count; z++)
            {
                // Create the tile with name Tile(i,0,j)
                GameObject newTile = Instantiate(tile, new Vector3(x, 0, z), Quaternion.identity);
                newTile.name = "Tile(" + x + "," + z + ")";

                // If the grid is an X, create a tower
                if (grid[x][z] == 'X')
                {
                    Instantiate(stone, new Vector3(x, 0, z), Quaternion.identity);
                }
            }
        }

        spawnWave();

    }

    // Update is called once per frame
    void Update()
    {
        // Change active tower on key press. 1,2,3
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeTower = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeTower = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activeTower = 2;
        }

        UpdateGUI();

    // Spawn more monsters if there are none left
    if (GameObject.FindGameObjectsWithTag("Monster").Length == 0)
    {
        level++;
        spawnWave();    


    }
    }

    void setupGrid()
    {
        grid = new List<List<char>>
    {
        new List<char> { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'O', 'X' },
        new List<char> { 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X' },
        new List<char> { 'X', 'O', 'X', 'X', 'X', 'X', 'X', 'X', 'X' },
        new List<char> { 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X' },
        new List<char> { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'O', 'X' },
        new List<char> { 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X' },
        new List<char> { 'X', 'O', 'X', 'X', 'X', 'X', 'X', 'X', 'X' },
    };

    }
    // Change text to show active tower
    void UpdateGUI()
    {
        // activeTowerText.GetComponent<TextMeshProUGUI>().text = "Active Tower: " + towers[activeTower].name;
        GameObject.Find("ActiveTowerText").GetComponent<TextMeshProUGUI>().text = "Active Tower: " + towers[activeTower].name;
        GameObject.Find("BatinText").GetComponent<TextMeshProUGUI>().text = "Batin: " + batin;
    }

    public GameObject getActiveTower()
    {
        return towers[activeTower];
    }

    public int getLevel()
    {
        return level;
    }

    public void spawnWave()
    {
        // Spawn 5 monsters with a delay of 1 second inbetween
        for (int i = 0; i < 5; i++)
        {
            Invoke("spawnMonster", 1.5f * i);
        }
    }

    void spawnMonster()
    {
        Instantiate(monster, new Vector3(-1, 0, 7), Quaternion.identity);
    }

    public bool spendBatin(int amount)
    {
        if (batin >= amount)
        {
            batin -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void addBatin(int amount)
    {
        batin += amount;
    }

    public void spawnTower(Vector3 position)
    {
        if (spendBatin(towers[activeTower].GetComponent<TowerManager>().cost))
        {
            Instantiate(towers[activeTower], position, Quaternion.identity);
        }
    }
}
