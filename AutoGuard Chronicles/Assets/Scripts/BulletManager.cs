using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private float speed = 10f;

    public int damage = 0;

    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(direction * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            Destroy(gameObject);
        }
    }

    public void setTarget(Vector3 target)
    {
        direction = target - transform.position;
        direction.Normalize();
        // Look at the target
        Vector3 lookAt = target - transform.position;
        lookAt.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookAt);
        transform.rotation = rotation;

    }



}
