using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerBlink : MonoBehaviour
{
    public GameObject pointerObject;
    private bool isHovered;

    private void Start()
    {
        isHovered = false;
        pointerObject.SetActive(false);
    }

    public void OnMouseEnter()
    {
        isHovered = true;
        pointerObject.SetActive(true);
        StartCoroutine(BlinkPointer());
    }

    public void OnMouseExit()
    {
        isHovered = false;
        pointerObject.SetActive(false);
    }

    IEnumerator BlinkPointer()
    {
        while (isHovered)
        {
            pointerObject.SetActive(true);
            yield return new WaitForSeconds(0.5f); // Adjust the time for your desired blink rate
            pointerObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
