﻿using System.Collections;
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

    public GameObject Header;
    public TextMeshProUGUI HeaderField;

    public GameObject Step;
    public TextMeshProUGUI StepField;

    public TextMeshProUGUI TimerField;
    
    public Button StartButton;
    public Button NextStepButton;
    public Button IngredientsButton;

    public CutOnions Onions;
    public CutOuts CutOuts;

    private List<Step> Instructions;
    private IEnumerator<Step> StepEnumerator;
    private float timer;
    private bool UpdateUI;
    private bool TimerSet = false;

    private void Start()
    {
        Ingredients.SetActive(false);
        UpdateUI = false;
        TimerField.enabled = false;
    }

    private void Update()
    {
        if(UpdateUI && StepEnumerator.Current != null)
        {
            switch (StepEnumerator.Current.Type)
            {
                case StepType.Onions:
                    Header.SetActive(false);
                    Step.SetActive(true);
                    Onions.StartOnionCutting();
                    StepField.text = StepEnumerator.Current.Number + ". " + StepEnumerator.Current.Description;
                    break;
                case StepType.Heading:
                    Header.SetActive(true);
                    Step.SetActive(false);
                    HeaderField.text = StepEnumerator.Current.Number.Substring(0,1)+ ". " + StepEnumerator.Current.Description;
                    break;
                case StepType.Timer:
                    Header.SetActive(false);
                    Step.SetActive(true);
                    timer = (float)StepEnumerator.Current.TimerInS;
                    TimerField.enabled = true;
                    TimerSet = true;
                    StepField.text = StepEnumerator.Current.Number + ". " + StepEnumerator.Current.Description;
                    break;
                case StepType.Circles:
                    Header.SetActive(false);
                    Step.SetActive(true);
                    StepField.text = StepEnumerator.Current.Number + ". " + StepEnumerator.Current.Description;
                    CutOuts.StartCutOuts();
                    break;
                case StepType.BasicStep:
                default:
                    Header.SetActive(false);
                    Step.SetActive(true);
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

    public void ToggleIngredients()
    {
        if(Ingredients.activeSelf)
        {
            CloseIngredients();
        } else
        {
            OpenIngredients();
        }
    }
    public void OpenIngredients()
    {
        Ingredients.SetActive(true);
        Step.SetActive(false);
        Header.SetActive(false);
        NextStepButton.gameObject.SetActive(false);
    }
    public void CloseIngredients()
    {
        Ingredients.SetActive(false);
        Step.SetActive(true);
        Header.SetActive(true);
        NextStepButton.gameObject.SetActive(true);
    }

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
        Step.SetActive(true);
        NextStepButton.gameObject.SetActive(true);
        IngredientsButton.gameObject.SetActive(true);
    }

    public void NextStep()
    {
        UpdateUI = true;
        StepEnumerator.MoveNext();
    }
}
