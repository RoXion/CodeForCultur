using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roommanager : MonoBehaviour
{
    public Textbox einführungsbox;

    void Start()
    {
        einführungsbox.ShowNextMessage();
    }

}
