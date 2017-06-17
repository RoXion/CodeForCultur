using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HercualesTextbox : Textbox
{
    [SerializeField]
    protected string[] textLines2;

    bool firstTextBoxisFinished = false;

    public Inventory inventory;

    public Item item;

    public Button thisButton;

    private bool showScondText = false;

    public override void ShowNextMessage()
    {
        if (!showScondText)
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
                firstTextBoxisFinished = true;
            }
        }
        else
        {
            StopCoroutine(WriteSecondTextInTextbox());

            if (currentMessageIndex <= textLines2.Length - 1)
            {
                textbox.text = "";
                StartCoroutine(WriteSecondTextInTextbox());

                currentMessageIndex++;
            }
            else
            {
                BackgroundButton.SetActive(false);


            }
        }

    }

    override protected IEnumerator WriteTextInTextbox()
    {

        foreach (char letter in textLines[currentMessageIndex].ToCharArray())
        {
            yield return new WaitForSeconds(delayBetweenLetter);
            textbox.text += letter;

        }

        if (currentMessageIndex > textLines.Length - 1)
        {
            firstTextBoxisFinished = true;
        }
    }


    public void UseSword()
    {
        if (firstTextBoxisFinished)
        {
            inventory.RemoveItem(item);
        }

        showScondText = true;
        currentMessageIndex = 0;
        ShowNextMessage();

    }
    

    protected IEnumerator WriteSecondTextInTextbox()
    {

        foreach (char letter in textLines2[currentMessageIndex].ToCharArray())
        {
            yield return new WaitForSeconds(delayBetweenLetter);
            textbox.text += letter;

        }

        if (currentMessageIndex > textLines2.Length - 1)
        {
            firstTextBoxisFinished = true;
        }
    }
}
