using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [Range(1, 5)]
    [Tooltip("The cost of the tower")]
    public int cost;

    [Range(1f, 100f)]
    [Tooltip("The damage of the tower")]
    public int damage;

    [Range(1f, 10f)]
    [Tooltip("The range of the tower")]
    public float range;

    [Range(0.1f, 5f)]
    [Tooltip("The fire rate of the tower")]
    public float fireRate;

    private float fireCountdown = 0f;

    public GameObject bulletPrefab;

    public string towerName;

    [Header("Upgrade Settings")]
    [Range(1, 10)]
    [Tooltip("The cost of the upgrade")]
    public int upgradeCost;

    [Range(1f, 100f)]
    [Tooltip("The damage of the upgrade")]
    public int upgradeDamage;

    [Range(1f, 10f)]
    [Tooltip("The range of the upgrade")]
    public float upgradeRange;

    [Range(0.1f, 5f)]
    [Tooltip("The fire rate of the upgrade")]
    public float upgradeFireRate;

    private int sellCost;

    private int level = 1;


    // Start is called before the first frame update
    void Start()
    {
        sellCost = cost;


    }

    // Update is called once per frame
    void Update()
    {

        if (fireCountdown <= 0f)
        {
            shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    private void shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
        BulletManager bullet = bulletGO.GetComponent<BulletManager>();

        if (bullet != null)
        {
            bullet.damage = damage;
            GameObject closestMonster = getClosestMonster();
            bullet.setTarget(closestMonster.transform.position);
        }
    }



    private GameObject getClosestMonster()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        GameObject closestMonster = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject monster in monsters)
        {
            float distance = Vector3.Distance(transform.position, monster.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestMonster = monster;
            }
        }

        return closestMonster;
    }

    public int getSellCost()
    {
        return sellCost;
    }
}
