using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image[] itemImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];

    public const int numItemSlots = 4;


    public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }

        Debug.Log("Inventar voll");
    }

    public void RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;

                for (int j = i+1; j < items.Length; j++)
                {
                    items[j-1] = items[j];
                    itemImages[j-1].sprite = itemImages[j].sprite;
                    itemImages[j-1].enabled = itemImages[j].enabled;

                    items[j] = null;
                    itemImages[j].sprite = null;
                    itemImages[j].enabled = false;
                }

                return;
            }
        }

        Debug.Log("Item nicht im Inventar");
    }
}
