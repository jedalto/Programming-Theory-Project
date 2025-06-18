using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Fruit
{
    private float bananaRotTime = 7.0f;
    private float bananaMass = 3.0f;

    protected override void Rotting()
    {
        if (bananaRotTime <= 0)
        {
            mainUIHandler.AddIngredient(fruitName);
            Destroy(gameObject);
            Debug.Log(fruitName + " rotted and was destroyed");
            // add this gameObject back to order and turn red

        }
        else
        {
            bananaRotTime -= Time.deltaTime;
        }
    }

    protected override void SetMass()
    {
        fruitMass = bananaMass;
        base.SetMass();
    }
}
