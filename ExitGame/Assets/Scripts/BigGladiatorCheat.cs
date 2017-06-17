using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGladiatorCheat : MonoBehaviour {

    public Textbox einführungsbox;

    public GameObject littleGladiators;

    public Inventory inventory;
    public Item Item;

    // Use this for initialization
    void Start () {
        einführungsbox.ShowNextMessage();

    }


    void OnDisable()
    {
        littleGladiators.SetActive(true);

        inventory.AddItem(Item);
    }

}
