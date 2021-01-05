using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutOuts : MonoBehaviour
{
    public GameObject CutOutWrapper;
    public GameObject PlacingArea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCutOuts()
    {
        PlacingArea.SetActive(true);
        StartCoroutine(AnimateCutOuts(CutOutWrapper.GetComponentsInChildren<Animator>()));
    }

    IEnumerator AnimateCutOuts(Animator[] animators)
    {
        foreach (Animator anim in animators)
        {
            yield return new WaitForSeconds(1);
            anim.Play("cutouts");
        }
    }
}
