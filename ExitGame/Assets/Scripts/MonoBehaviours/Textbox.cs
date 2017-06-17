using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Textbox : MonoBehaviour
{
    [SerializeField]
    private string[] textLines;

    [SerializeField]
    [Range(0.01f, 0.05f)]
    private float delayBetweenLetter = 0.03f;

    [SerializeField]
    private TextMeshProUGUI textbox;

    [SerializeField]
    private GameObject BackgroundButton;

    private int currentMessageIndex;

	// Use this for initialization
	void Start ()
	{
	    textbox.text = "";
	}


    IEnumerator WriteTextInTextbox()
    {

        foreach (char letter in textLines[currentMessageIndex].ToCharArray())
        {
            yield return new WaitForSeconds(delayBetweenLetter);
            textbox.text += letter;
            
        }
    }

    public void ShowNextMessage()
    {
        StopCoroutine(WriteTextInTextbox());

        if (currentMessageIndex < textLines.Length - 1)
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
