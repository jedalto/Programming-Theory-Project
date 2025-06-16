using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private float lowerBounds = -4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckLowerBounds();
    }

    void CheckLowerBounds()
    {
        if (transform.position.y < lowerBounds)
            Destroy(gameObject);
    }
}
