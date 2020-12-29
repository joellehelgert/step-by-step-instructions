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
    public TextMeshProUGUI TimerField;

    public GameObject HeadlinePrefab;

    private List<Step> Instructions;
    private IEnumerator<Step> StepEnumerator;
    private float timer;
    private bool UpdateUI;
    private bool TimerSet = false;

    private void Start()
    {
        Ingredients.SetActive(false);
        UpdateUI = false;
        // StartButton.interactable = false;
        // fill ingredients in textfield
        // hide textfield & close
        TimerField.enabled = false;
    }

    private void Update()
    {
        if(UpdateUI && StepEnumerator.Current != null)
        {
            switch(StepEnumerator.Current.Type)
            {
                case StepType.Onions:
                    break;
                case StepType.Heading:
                    StepField.text = "HEADING";
                    break;
                case StepType.Timer:
                    timer = (float)StepEnumerator.Current.TimerInS;
                    TimerField.enabled = true;
                    TimerSet = true;
                    StepField.text = StepEnumerator.Current.Number + ". " + StepEnumerator.Current.Description;
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

        if(TimerSet)
        {
            if (timer <= 0) {
                TimerSet = false;
                TimerField.enabled = false;
            } else
            {
                timer -= Time.deltaTime;
                int minutes = (int)timer / 60;
                int sec = (int)timer - minutes * 60;
                TimerField.text = minutes + ":" + sec;
            }

        }
    }

    public void OpenIngredients() => Ingredients.SetActive(true);
    public void CloseIngredients() => Ingredients.SetActive(false);

    public void PaintIngredients(List<Ingredient> ingredients)
    {        
        foreach (Ingredient ingredient in ingredients) {
            switch (ingredient.Part)
            {
                case "Dough":
                    Dough.text = Dough.text + PrintIngredient(ingredient);
                    break;
                case "Filling":
                    Filling.text = Filling.text + PrintIngredient(ingredient);
                    break;
                case "Sauce":
                    Sauce.text = Sauce.text + PrintIngredient(ingredient);
                    break;
            }
        }
    }

    private string PrintIngredient(Ingredient ingredient)
    {
        return ingredient.Amount + "  " + ingredient.Unit + "  " + ingredient.Name + "\n";
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
