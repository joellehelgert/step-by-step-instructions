using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInteractables : MonoBehaviour
{
    public GameObject Ingredients;
    public TextMeshProUGUI Dough;
    public TextMeshProUGUI Filling;
    public TextMeshProUGUI Sauce;
    public Button StartButton;
    public GameObject Step;
    public TextMeshProUGUI StepField;
    public Button NextStepButton;

    public GameObject HeadlinePrefab;

    private List<Step> Instructions;
    private IEnumerator<Step> StepEnumerator;
    private bool UpdateUI;

    private void Start()
    {
        Ingredients.SetActive(false);
        UpdateUI = false;
        // StartButton.interactable = false;
        // fill ingredients in textfield
        // hide textfield & close
    }

    private void Update()
    {
        if(UpdateUI && StepEnumerator.Current != null)
        {
            // check type of instruction
            // paint
            switch(StepEnumerator.Current.Type)
            {
                case StepType.Onions:
                    break;
                case StepType.Heading:
                    StepField.text = "HEADING";
                    break;
                case StepType.Timer:
                    break;
                case StepType.Circles:
                    break;
                case StepType.BasicStep:
                default:
                    StepField.text = StepEnumerator.Current.Number + ". " +StepEnumerator.Current.Description;
                    break;
            }

            UpdateUI= false;
        } else if (UpdateUI && StepEnumerator.Current == null)
        {
            StepField.text = "DONE";
            UpdateUI = false;
            NextStepButton.interactable = false;
        }
    }

    public void OpenIngredients() => Ingredients.SetActive(true);
    public void CloseIngredients() => Ingredients.SetActive(false);

    public void PaintIngredients(List<Ingredient> ingredients)
    {
        /*
        Debug.Log(GameObject.Find("Dough"));
        GameObject.Find("Dough").TryGetComponent<TextMeshPro>(out TextMeshPro Dough);
        Ingredients.GetComponent("Filling").TryGetComponent<TextMeshPro>(out TextMeshPro Filling);
        Ingredients.GetComponent("Sauce").TryGetComponent<TextMeshPro>(out TextMeshPro Sauce);
        */
        
        foreach (Ingredient ingredient in ingredients) {
            switch (ingredient.Part)
            {
                case "Dough":
                    Dough.text = Dough.text + ingredient.Name + "\n";
                    break;
                case "Filling":
                    Filling.text = Filling.text + ingredient.Name + "\n";
                    break;
                case "Sauce":
                    Sauce.text = Sauce.text + ingredient.Name + "\n";
                    break;
            }
        }
    }

    public void EnableStart(List<Step> instructions) {
        StartButton.interactable = true;
        Instructions = instructions;
    }

    public void StartCooking() 
    {
        StartButton.gameObject.SetActive(false);
        StepEnumerator = Instructions.GetEnumerator();
        StepEnumerator.MoveNext();
        UpdateUI = true;
    }

    public void NextStep()
    {
        UpdateUI = true;
        StepEnumerator.MoveNext();
    }
}
