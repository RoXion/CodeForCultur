using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBesCheat : MonoBehaviour {

    public Textbox einführungsbox;

    public GameObject littleBes;

    void Start()
    {
        einführungsbox.ShowNextMessage();
    }

    void OnDisable()
    {
        littleBes.SetActive(true);

    }

}
