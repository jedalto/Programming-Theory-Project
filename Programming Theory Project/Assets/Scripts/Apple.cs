using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Apple : Fruit
{
    private float appleRotTime = 15.0f;
    private float appleMass = 3.0f;

    // POLYMORPHISM
    protected override void Rotting()
    {
        if (appleRotTime <= 0)
        {
            mainUIHandler.AddIngredient(fruitName);
            Destroy(gameObject);
            Debug.Log(fruitName + " rotted and was destroyed");
            // add this gameObject back to order and turn red

        }
        else
        {
            appleRotTime -= Time.deltaTime;
        }
    }

    protected override void SetMass()
    {
        fruitMass = appleMass;
        base.SetMass();
    }
}
