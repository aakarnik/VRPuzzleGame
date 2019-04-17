using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePlacer : MonoBehaviour
{
    private GameObject puzzlePlacementObj;
    private GameObject puzzlePiece;

    public int PieceNumber = 1;

    //tolerance should allow the player to win when the piece is within a certain area of the placer
    //set to the number of units the piece moves along both axis

    public float xTolerance = 0.001f;
    public float yTolerance = 0.001f;
    public float zTolerance = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
     puzzlePlacementObj = GameObject.FindGameObjectWithTag("placer" + PieceNumber).gameObject;
     puzzlePiece = GameObject.FindGameObjectWithTag("puzpiece" + PieceNumber).gameObject;
     
    }

    bool isSolved()
    {
        //Needs TESTING

        Vector3 piecePosition = puzzlePiece.transform.position;
        Vector3 placePosition = puzzlePlacementObj.transform.position;

        if((piecePosition.x >= placePosition.x + xTolerance) &&
                piecePosition.y <= (placePosition.y + yTolerance) || piecePosition.y >= (placePosition.y - yTolerance) &&
                piecePosition.z <= (placePosition.z + zTolerance) || piecePosition.z >= (placePosition.z - zTolerance)) {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSolved() == true)
        {
            puzzlePlacementObj.GetComponent<Renderer>().material.color = Color.yellow;
        }
        
    }
}
