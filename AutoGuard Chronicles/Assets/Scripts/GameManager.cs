using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject tile;
    private int batin = 20;

   // List of possible towers
    public GameObject[] towers;
    private int activeTower = 0;

    // ActiveTowerText
    public TextMeshProUGUI activeTowerText;


    // Start is called before the first frame update
    void Start()
    {
        

        
        
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


        
        
    }

    // Change text to show active tower
    void UpdateGUI()
    {
        activeTowerText.text = "Active Tower: " + towers[activeTower].name;
    }


    public GameObject getActiveTower()
    {
        return towers[activeTower];
    }
}
