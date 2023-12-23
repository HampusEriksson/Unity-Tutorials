using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Material material;

    void Start()
    {



        material = Renderer.material;


    }

    void Update()
    {
        transform.position = new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(-5.0f, 5.0f));
        transform.Rotate(Random.Range(-10.0f, 10.0f) * Time.deltaTime, 0.0f, 0.0f);
        material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        transform.localScale = Vector3.one * Random.Range(0.0f, 5.0f);
    }
}
