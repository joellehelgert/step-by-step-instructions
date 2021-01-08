using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Vuforia;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScanRecipeCode : MonoBehaviour
{
    [Header("UI-Texts")]
    public string IdleText;
    public string SuccessText;
    public string ErrorText;


    [Header("UI-Elements")]
    public TMP_Text status;
    public Button StartButton;

    [Header("Recipe Target")]
    public TrackableBehaviour recipe;

    void Start()
    {
        status.text = IdleText;
        StartButton.interactable = false;
    }

    void Update()
    {
        if(recipe.CurrentStatus == TrackableBehaviour.Status.DETECTED || recipe.CurrentStatus == TrackableBehaviour.Status.TRACKED)
        {
            status.text = SuccessText + " vegan Gyozas";
            StartButton.interactable = true;
            Config.setCurrentRecipePath("Gyozas");
        }

    }

    public void ChangeScene ()
    {
        SceneManager.LoadScene("Gyozas");
    }

    
}
