using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] fruit;
    private float xBounds = 4.35f;
    private float yBounds = 4.25f;
    private float zBounds = -7.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomFruit", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomFruit()
    {
        int fruitIndex = Random.Range(0, fruit.Length);
        Vector3 randomPosition = new Vector3(Random.Range(-xBounds, xBounds), yBounds, zBounds);
        Instantiate(fruit[fruitIndex], randomPosition, transform.rotation);
    }
}
