
using UnityEngine;
using UnityEngine.UI;

public class BigGladiatorCheat : MonoBehaviour {

    public Textbox einführungsbox;

    public GameObject littleGladiators;

    public Inventory inventory;

    public Item item;
    public Sprite swordsprite;

    // Use this for initialization
    void Start () {
        einführungsbox.ShowNextMessage();

    }


    void OnDisable()
    {
        littleGladiators.SetActive(true);

        //item = new Item();
        //item.sprite = swordsprite;

        inventory.AddItem(item);
    }

}
