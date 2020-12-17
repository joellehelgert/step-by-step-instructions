using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public class RecipeManager : MonoBehaviour
{
    Recipe recipe;

    void Start()
    {
        recipe = new Recipe();
        LoadRecipeData();
    }

    void Update()
    {
        
    }

    private void LoadRecipeData()
    {
        string path = Config.currentRecipePath;

        LoadIngredients(path + "/Ingredients");
        LoadInstructions(path + "/Instructions");
    }

    private void LoadIngredients(string path)
    {
        Debug.LogWarning("path: " + path);
        TextAsset data = Resources.Load<TextAsset>(path);
        string[] dataRows = data.text.Split(new char[] { '\n' });

        for (int i = 1; i < dataRows.Length - 1; i++)
        {
            string[] row = dataRows[i].Split(new char[] { ';' });
            Ingredient ingredient = new Ingredient(float.Parse(row[0]), row[1], row[2], row[3]);
            recipe.Ingredients.Add(ingredient);
        }
    }

    private void LoadInstructions(string path)
    {
        Debug.Log("--------------- load instructions");
        TextAsset data = Resources.Load<TextAsset>(path);
        string[] dataRows = data.text.Split(new char[] { '\n' });

        for (int i = 1; i < dataRows.Length - 1; i++)
        {
            string[] row = dataRows[i].Split(new char[] { ';' });
            StepType type = (StepType)Enum.Parse(typeof(StepType), row[2]);
            Debug.LogWarning("row 4 " + row[4] + " length: " + row[4].Length);
            float f;
            int? seconds = float.TryParse(row[4], out f) ? (int?)f : null; 
            Step step = new Step(float.Parse(row[0]), row[1], type, row[3], seconds);

        }
    }
}