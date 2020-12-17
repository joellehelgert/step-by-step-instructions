using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config 
{
    // current Recipe
    // Dictonary with (image) targets to recipes and paths to recipes

    public static string currentRecipePath = "Recipes/Gyozas";  

    public static void setCurrentRecipePath(string path)
    {
        currentRecipePath = "Recipes/" + path;
    }
}
