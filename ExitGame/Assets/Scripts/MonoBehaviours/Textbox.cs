using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Textbox : MonoBehaviour
{
    [SerializeField]
    protected string[] textLines;

    [SerializeField]
    [Range(0.01f, 0.05f)]
    protected float delayBetweenLetter = 0.03f;

    [SerializeField]
    protected TextMeshProUGUI textbox;

    [SerializeField]
    protected GameObject BackgroundButton;

    protected int currentMessageIndex;

	// Use this for initialization
	void Start ()
	{
	    textbox.text = "";
	}


    protected virtual IEnumerator WriteTextInTextbox()
    {

        foreach (char letter in textLines[currentMessageIndex].ToCharArray())
        {
            yield return new WaitForSeconds(delayBetweenLetter);
            textbox.text += letter;
            
        }
    }

    public virtual void ShowNextMessage()
    {
        StopCoroutine(WriteTextInTextbox());

        if (currentMessageIndex <= textLines.Length - 1)
        {
            textbox.text = "";
            StartCoroutine(WriteTextInTextbox());

            currentMessageIndex++;
        }
        else
        {
            BackgroundButton.SetActive(false);
        }

    }
}
