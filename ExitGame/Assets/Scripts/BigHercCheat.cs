using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigHercCheat : MonoBehaviour {

    public Textbox einführungsbox;

    public GameObject littleBes;

    public GameObject puzzel;

    void Start()
    {
        einführungsbox.ShowNextMessage();
    }

    void OnDisable()
    {
        littleBes.SetActive(true);
        //puzzel.SetActive(true);
        SceneManager.LoadScene(2);

    }
}
