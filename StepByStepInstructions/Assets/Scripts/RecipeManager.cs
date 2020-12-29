using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public class RecipeManager : MonoBehaviour
{
    Recipe recipe;
    [SerializeField]
    public UIInteractables UI;

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
        TextAsset data = Resources.Load<TextAsset>(path);
        string[] dataRows = data.text.Split(new char[] { '\n' });

        for (int i = 1; i < dataRows.Length - 1; i++)
        {
            string[] row = dataRows[i].Split(new char[] { ';' });
            Ingredient ingredient = new Ingredient(float.Parse(row[0]), row[1], row[2], row[3].Trim());
            recipe.Ingredients.Add(ingredient);
        }

        UI.PaintIngredients(recipe.Ingredients);
    }

    private void LoadInstructions(string path)
    {
        TextAsset data = Resources.Load<TextAsset>(path);
        string[] dataRows = data.text.Split(new char[] { '\n' });

        for (int i = 1; i < dataRows.Length - 1; i++)
        {
            string[] row = dataRows[i].Split(new char[] { ';' });
            StepType type = (StepType)Enum.Parse(typeof(StepType), row[2]);
            int? seconds = float.TryParse(row[4], out float f) ? (int?)f * 60 : null;
            Step step = new Step(float.Parse(row[0]), row[1], type, row[3], seconds);
            recipe.Instructions.Add(step);

        }

        UI.EnableStart(recipe.Instructions);
    }
}