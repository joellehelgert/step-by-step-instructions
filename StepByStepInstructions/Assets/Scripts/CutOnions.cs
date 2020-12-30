using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Vuforia;

public class CutOnions : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject HintText;
    public GameObject PlacingArea;
    private int phase = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlacingArea.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        HintText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (phase)
        {
            case 1:
                HintText.SetActive(true);
                Debug.Log("Case 1");
                break;
            case 2:
                Debug.Log("Case 2");
                // HintText.SetActive(false);
                HintText.GetComponentInChildren<TextMeshPro>().text = "phase 2";
                break;
            case 3:
                Debug.Log("Case 3");
                HintText.GetComponentInChildren<TextMeshPro>().text = "phase 3";
                break;
            default:
                break;
        }
    }

    public void StartOnionCutting() => phase = 1;

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        HintText.SetActive(false);
        phase++;
        WaitAndSetPhase3(2);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }

    IEnumerator WaitAndSetPhase3(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        phase = 3;
    }
}
