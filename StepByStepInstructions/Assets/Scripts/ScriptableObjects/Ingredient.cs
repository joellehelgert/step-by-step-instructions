using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient
{
    public float Amount;
    public string Unit;
    public string Name;
    public string Part;

    public Ingredient(float amount, string unit, string name, string part)
    {
        Amount = amount;
        Unit = unit;
        Name = name;
        Part = part;
    }
}
