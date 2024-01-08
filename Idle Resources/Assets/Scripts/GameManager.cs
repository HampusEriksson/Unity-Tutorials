using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // A list of prefabs to spawn
    public GameObject[] resources;

    public GameObject harvester;
    // The number of resources to spawn
    private int startingResources = 10;

    // Total number of spawned resources
    public int spawnedResources = 0;

    // Number of looted resources
    private int wood = 0;

    // Map size
    private float mapSizeX;
    private float mapSizeZ;

    private float spawnRate = 10f;

    private int harvesterPrice = 3;
    private int treeSpawnRatePrice = 3;
    private int harvesterSpeedPrice = 3;

    private int harvesters = 0;

    // Start is called before the first frame update
    void Start()
    {
        mapSizeX= 50;
        mapSizeZ = 50;
        

        // Create the starting resources
        for (int i = 0; i < startingResources; i++)
        {
            // Generate a random position
            Vector3 position = getRandomPosition();

            // Generate a random index
            int index = Random.Range(0, resources.Length);

            // Spawn the resource
            Instantiate(resources[index], position, Quaternion.identity);

            // Increment the number of spawned resources
            spawnedResources++;
        }

        StartCoroutine(SpawnResource());

        // Create a harvester
        spawnHarvester();

            GameObject.Find("HarvesterButton").GetComponentInChildren<TextMeshProUGUI>().text = "Buy Harvester\nHarvesters: "+ harvesters.ToString()+"\nWood: " + harvesterPrice.ToString();
            GameObject.Find("TreeSpawnButton").GetComponentInChildren<TextMeshProUGUI>().text = "Tree Spawnrate\nCurrent rate: "+ spawnRate.ToString()+"\nWood: " + treeSpawnRatePrice.ToString();
            GameObject.Find("HarvesterSpeedButton").GetComponentInChildren<TextMeshProUGUI>().text = "Harvester Speed\nCurrent speed: " + Mathf.Round((100f * 1.0f + 0.1f * (harvesterSpeedPrice - 10)) / 100f).ToString() + "\nWood: " + harvesterSpeedPrice.ToString();
    

        
    }

    void spawnHarvester()
    {
        Instantiate(harvester, new Vector3(5, 3.5f, 5), Quaternion.identity);
        harvesters++;
    }

    // Update is called once per frame
    void Update()
    {
        // Change the text of the text that shows the amount of wood
        GameObject.Find("AmountWood").GetComponent<TextMeshProUGUI>().text = "Wood: " + wood.ToString();
        
    }


// Create a tree every 5 seconds
    IEnumerator SpawnResource()
    {


        // Wait for 5 seconds
        yield return new WaitForSeconds(spawnRate);

        // Generate a random position
        Vector3 position = getRandomPosition();

        // Generate a random index
        int index = Random.Range(0, resources.Length);

        // Spawn the resource
        GameObject resource = Instantiate(resources[index], position, Quaternion.identity);

        // Increment the number of spawned resources
        spawnedResources++;

        // Restart the coroutine
        StartCoroutine(SpawnResource());
        
    }
        
      


    

private Vector3 getRandomPosition()
{
    Vector3 position;

    do
    {
        // Generate a random position
        position = new Vector3(Random.Range(-mapSizeX, mapSizeX), 0, Random.Range(-mapSizeZ, mapSizeZ));
    }
    while (position.x >= -10 && position.x <= 10 && position.z >= -10 && position.z <= 10);

    return position;
}

    public void buyHarvester()
    {
        if (wood >= harvesterPrice)
        {
            wood -= harvesterPrice;
            harvesterPrice ++;
            spawnHarvester();
            // Change the text of the button to show the amount of harvesters
            GameObject.Find("HarvesterButton").GetComponentInChildren<TextMeshProUGUI>().text = "Buy Harvester\nHarvesters: "+ harvesters.ToString()+"\nWood: " + harvesterPrice.ToString();


        }
    }

    public void increaseTreeSpawnRate()
    {
        if (wood >= treeSpawnRatePrice)
        {
            wood -= treeSpawnRatePrice;
            spawnRate *= 0.9f;
            treeSpawnRatePrice ++;
            // Change the text of the button
                    GameObject.Find("TreeSpawnButton").GetComponentInChildren<TextMeshProUGUI>().text = "Tree Spawnrate\nCurrent rate: "+ spawnRate.ToString()+"\nWood: " + treeSpawnRatePrice.ToString();
        }
    }

    public void increaseHarvesterSpeed()
    {
        if (wood >= harvesterSpeedPrice)
        {
            wood -= harvesterSpeedPrice;
            harvesterSpeedPrice ++;

            // Change the text of the button
GameObject.Find("HarvesterSpeedButton").GetComponentInChildren<TextMeshProUGUI>().text = "Harvester Speed\nCurrent speed: " + Mathf.Round((100f * 1.0f + 0.1f * (harvesterSpeedPrice - 10)) / 100f).ToString() + "\nWood: " + harvesterSpeedPrice.ToString();

            // Change the speed of all harvesters
            GameObject[] harvesters = GameObject.FindGameObjectsWithTag("Harvester");
            foreach (GameObject harvester in harvesters)
            {
                harvester.GetComponent<HarvesterManager>().increaseSpeed(0.1f);
            }
            
        }
    }

    public void Unload(int amount)
    {
        wood += amount;
    }

}
