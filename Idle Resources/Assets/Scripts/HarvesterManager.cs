using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvesterManager : MonoBehaviour
{
    private GameObject house;
    private string currentTask = "Gathering";
    private GameObject gameManager;
  

    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    private float speed = 5f;




    // Start is called before the first frame update
    void Start()
    {

        house = GameObject.Find("House");
        gameManager = GameObject.Find("Game Manager");
        inventory.Add("Wood", 0);
        
    }

    // Update is called once per frame
    void Update()
    {

        // If gathering, rotate towards the nearest resource
        if (currentTask == "Gathering")
{
    // Find the nearest resource
    GameObject[] resources = GameObject.FindGameObjectsWithTag("Tree");
    GameObject nearestResource = null;
    float distance = Mathf.Infinity;

    foreach (GameObject resource in resources)
    {
        float currentDistance = Vector3.Distance(transform.position, resource.transform.position);
        if (currentDistance < distance)
        {
            distance = currentDistance;
            nearestResource = resource;
        }
    }

    // Rotate towards the nearest resource (if found)
    if (nearestResource != null)
    {
        LookAtGameObject(nearestResource);
    }
    else
    {
        Debug.LogWarning("No nearest resource found.");
    }
}

        // Move forward

        if (currentTask != "Harvesting")
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        
    }

private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Tree") && currentTask == "Gathering")
    {
        currentTask = "Harvesting";
        
        // Harvest the resource
        StartCoroutine(HarvestResource(other.gameObject));
    }
    else if (other.gameObject.CompareTag("House")  && currentTask == "Returning")
    {
        // If the harvester is returning, unload the resources
        gameManager.GetComponent<GameManager>().Unload(inventory["Wood"]);
        inventory["Wood"] = 0;
        changeTask("Gathering");
    }
}

private IEnumerator HarvestResource(GameObject resource)
{
    
    while (currentTask == "Harvesting" && resource != null)
    {
        // Harvest the resource
        bool harvested = resource.GetComponent<Resource>().harvest();

        // If the resource was harvested
        if (harvested)
        {
            inventory["Wood"]++;

            // Delay for 1 second
            yield return new WaitForSeconds(1.0f);

            // If the sum of the inventory is greater than 5, move back to the house
            if (inventory["Wood"] >= 5)
            {
                changeTask("Returning");
            }else if (resource == null)
            {
                changeTask("Gathering");
            }
        }

        yield return null; // Yielding null allows the coroutine to continue in the next frame
    }
}


    void LookAtGameObject(GameObject target){
        // Get the direction towards the house in 2D (XZ plane)
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0; // Set the Y component to zero to keep it in the XZ plane

        // Calculate the rotation to look at the house in the XZ plane only
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Apply the rotation only around the Y-axis (keep other axes unchanged)
        Vector3 eulerAngles = targetRotation.eulerAngles;
        eulerAngles.x = 0;
        eulerAngles.z = 0;
        targetRotation = Quaternion.Euler(eulerAngles);

        // Set the object's rotation
        transform.rotation = targetRotation;
    }

      IEnumerator DelayedAction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
    }

    void changeTask(string newTask)
    {
        currentTask = newTask;
        if (currentTask == "Returning")
        {
            LookAtGameObject(house);
        }
        
    }

    public void increaseSpeed(float increase)
    {
        speed += increase;
    }
}
