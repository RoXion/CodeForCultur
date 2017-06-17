using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBar : MonoBehaviour
{
    [SerializeField]
    private GameObject inventory;
    

    public void OnInventoryButtonClicked()
    {
        inventory.SetActive(!inventory.activeSelf);
    }
}
