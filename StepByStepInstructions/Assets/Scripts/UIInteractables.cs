using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInteractables : MonoBehaviour
{
    public GameObject Ingredients;
    public GameObject Data; // probs not GameObject

    public GameObject HeadlinePrefab;
    public GameObject IngredientPrefab;

    private void Start()
    {
        Ingredients.SetActive(false);
        // fill ingredients in textfield
        PaintIngredients();
        // hide textfield & close
    }

    public void OpenIngredients() => Ingredients.SetActive(true);
    public void CloseIngredients() => Ingredients.SetActive(false);

    public void PaintIngredients()
    {
        // TODO
    }
}
