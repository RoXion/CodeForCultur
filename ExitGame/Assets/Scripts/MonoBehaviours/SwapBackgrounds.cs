using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapBackgrounds : MonoBehaviour
{
    [SerializeField]
    private GameObject[] backgrounds = new GameObject[4];

    private int currentWallIndex = 0;


    public void MoveLeft()
    {
        backgrounds[currentWallIndex].SetActive(false);

        if (currentWallIndex != 0)
        {
            currentWallIndex--;
        }
        else
        {
            currentWallIndex = backgrounds.Length - 1;
        }

        backgrounds[currentWallIndex].SetActive(true);
    }

    public void MoveRight()
    {
        backgrounds[currentWallIndex].SetActive(false);

        if (currentWallIndex != backgrounds.Length - 1)
        {
            currentWallIndex++;
        }
        else
        {
            currentWallIndex = 0;
        }

        backgrounds[currentWallIndex].SetActive(true);
    }

}
