using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Vuforia;

public class CutOnions : MonoBehaviour, IVirtualButtonEventHandler
{
    public TextMeshPro HintText;
    public GameObject PlacingArea;
    public GameObject HorizontalGrid;
    public GameObject VerticalGrid;
    public GameObject CutOnion;
    private bool cutting;

    // Start is called before the first frame update
    void Start()
    {
        PlacingArea.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartOnionCutting()
    {
        CutOnion.SetActive(true);
        cutting = true;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if(cutting)
        {
            Animator[] hanimators = HorizontalGrid.GetComponentsInChildren<Animator>();
            Animator[] vanimators = VerticalGrid.GetComponentsInChildren<Animator>();
            StartCoroutine(DrawLines(hanimators,vanimators));
        }

    }

    IEnumerator DrawLines(Animator[] hanimators, Animator[] vanimators)
    {
        HintText.text = "2. Cut the onion horizontally as shown by the lines";
        foreach (Animator anim in hanimators)
        {
            yield return new WaitForSeconds(1);
            anim.Play("line_anim");
        }

        HintText.text = "3. Now, cut the onion vertically as shown by the lines";
        foreach (Animator anim in vanimators)
        {
            yield return new WaitForSeconds(1);
            anim.Play("line_anim");
        }

        yield return new WaitForSeconds(5);

        CutOnion.SetActive(false);
        cutting = false;
    }
}
