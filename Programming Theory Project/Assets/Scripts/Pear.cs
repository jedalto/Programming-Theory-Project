using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Pear : Fruit
{
    private float pearRotTime = 10.0f;
    private float pearMass = 3.0f;

    // POLYMORPHISM
    protected override void Rotting()
    {
        if (pearRotTime <= 0)
        {
            mainUIHandler.AddIngredient(fruitName);
            Destroy(gameObject);
            Debug.Log(fruitName + " rotted and was destroyed");
            // add this gameObject back to order and turn red

        }
        else
        {
            pearRotTime -= Time.deltaTime;
        }
    }

    protected override void SetMass()
    {
        fruitMass = pearMass;
        base.SetMass();
    }
}
