using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonAction : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject NextButton;
    public GameObject IngredientsButton;
    public UIInteractables UIManager;

    private Animator NextAnimator;
    private Animator IngredientAnimator;
    // Start is called before the first frame update
    void Start()
    {
        NextButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        NextAnimator = NextButton.GetComponentInChildren<Animator>();
        IngredientsButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        IngredientAnimator = IngredientsButton.GetComponentInChildren<Animator>();
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button pressed");
        Debug.Log("-------------" + vb.gameObject);
        if (vb.gameObject == NextButton)
        {
            NextAnimator.Play("button_down");
        }
        else {
            IngredientAnimator.Play("button_down");
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (vb.gameObject == NextButton)
        {
            UIManager.NextStep();
            NextAnimator.Play("button_up");
        }
        else
        {
            UIManager.OpenIngredients();
            IngredientAnimator.Play("button_up");
        }
        Debug.Log("Button released");
    }
}
