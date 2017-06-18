using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class MovePiece : MonoBehaviour
{

    public String pieceStatus = "idle";

    public KeyCode placePiece;
    public KeyCode returnToInv;

    public String checkPlacement;

    public float yDiff;
    public Vector2 invPOS;

    public static int numOfAlllPieces = 25;
    public static int numOfSetPieces = 0;

    public TextMeshProUGUI geschaftText;

    // Use this for initialization
    void Start () {

	    invPOS = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
	{

	    InvControl();


        if (pieceStatus == "pickedup")
	    {
	        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
	        Vector2 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
	        transform.position = objectPosition;
	    }

	    if (Input.GetKeyDown(placePiece) && pieceStatus == "pickedup")
	    {
	        checkPlacement = "y";
	    }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.name == gameObject.name) && checkPlacement == "y")
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Renderer>().sortingOrder = 0;
            transform.position = other.gameObject.transform.position;
            pieceStatus = "locked";
            checkPlacement = "n";
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
            numOfSetPieces++;

            if (numOfSetPieces == numOfAlllPieces)
            {
                
                geschaftText.gameObject.SetActive(true);
            }
        }

        if ((other.gameObject.name != gameObject.name) && checkPlacement == "y")
        {
            GetComponent<SpriteRenderer>().color = new Color(1,1,1, 0.5f);
            checkPlacement = "n";
        }
    }

    void OnMouseDown()
    {
        pieceStatus = "pickedup";
        checkPlacement = "n";
        GetComponent<Renderer>().sortingOrder = 10;
    }

    void InvControl()
    {
        if ((Input.GetAxis("Mouse ScrollWheel") > 0) && pieceStatus != "locked")
        {
            transform.position = new Vector2(-7.7f, transform.position.y +2.2f);
            yDiff += 2.2f;
        }
        else if ((Input.GetAxis("Mouse ScrollWheel") < 0) && pieceStatus != "locked")
        {
            transform.position = new Vector2(-7.7f, transform.position.y - 2.2f);
            yDiff -= 2.2f;
        }

        if ((Input.GetKeyDown(returnToInv)) && pieceStatus == "pickedup")
        {
            transform.position = new Vector2(-7.7f, invPOS.y + yDiff);
            pieceStatus = "idle";
        }
    }
}
