using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private float speed = 10f;

    public int damage = 0;

    public Vector3 direction;

    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the target
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            MonsterManager monster = other.GetComponent<MonsterManager>();
            monster.takeDamage(damage);
        }
    }

    public void setTarget(GameObject newtarget)
    {

        target = newtarget;
        

    }





}
