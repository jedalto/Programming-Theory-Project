using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private float lowerBounds = -4.0f;
    public string fruitName { get; set; }
    private Renderer fruitRenderer;
    private Rigidbody rb;
    public float fruitMass { get; set; } = 1.0f;
    private bool isCaught = false;
    private float rotTime = 10.0f;

    protected MainUIHandler mainUIHandler;

    // Start is called before the first frame update
    void Start()
    {
        fruitRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
        
        DetermineFruitName();
        mainUIHandler = FindObjectOfType<MainUIHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckLowerBounds();
        if (isCaught)
            Rotting();
    }

    void CheckLowerBounds()
    {
        if (transform.position.y < lowerBounds)
            Destroy(gameObject);
    }

    protected virtual void Rotting()
    {
        if (rotTime <= 0)
        {
            mainUIHandler.AddIngredient(fruitName);
            Destroy(gameObject);
            Debug.Log(fruitName + " rotted and was destroyed");
            // add this gameObject back to order and turn red
            
        } else
        {
            rotTime -= Time.deltaTime;
        }
    }

    protected virtual void SetMass()
    {
        rb.mass = fruitMass;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Catcher") || 
                collision.gameObject.CompareTag("Banana") ||
                collision.gameObject.CompareTag("Pear") ||
                collision.gameObject.CompareTag("Apple"))
        {
            gameObject.transform.SetParent(collision.transform);

            Debug.Log(fruitName + " was caught in the pitcher");
            if (isCaught == false)
            {
                if (!mainUIHandler.CheckGameOver(fruitName))
                {
                    Destroy(gameObject);
                }
            }
            isCaught = true;

        }
    }

    void DetermineFruitName()
    {
        if (gameObject.CompareTag("Pear"))
            fruitName = "Pear";
        else if (gameObject.CompareTag("Apple"))
            fruitName = "Apple";
        else if (gameObject.CompareTag("Banana"))
            fruitName = "Banana";
        else
            fruitName = "Apple";
        Debug.Log("fruitName = " + fruitName);
    }
}
