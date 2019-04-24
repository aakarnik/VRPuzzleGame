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

    private float xTolerance = 0.001f;
    private float yTolerance = .05f;
    private float zTolerance = .05f;

    //TESTING
    private int update_pts_once = 1;
    private int solvedCount = 0;

    //This is the format of the type of function we want to access
    //In this case we want to access void, int
    public delegate void PuzzleComplete(int pts);
    public static event PuzzleComplete onPuzzleComplete;

    // Start is called before the first frame update
    void Start()
    {
     puzzlePlacementObj = GameObject.FindGameObjectWithTag("placer" + PieceNumber).gameObject;
     puzzlePiece = GameObject.FindGameObjectWithTag("puzpiece" + PieceNumber).gameObject;
     
    }

    bool isSolved()
    {
        //Working
        Vector3 piecePosition = puzzlePiece.transform.position;
        Vector3 placePosition = puzzlePlacementObj.transform.position;

        
        if((piecePosition.x >= placePosition.x + xTolerance) &&
                piecePosition.y < (placePosition.y + yTolerance) && piecePosition.y > (placePosition.y - yTolerance) &&
                piecePosition.z < (placePosition.z + zTolerance) && piecePosition.z > (placePosition.z - zTolerance)) {
            return true;
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        //Working
        if (isSolved() == true)
        {
            puzzlePlacementObj.GetComponent<Renderer>().material.color = Color.yellow;
            solvedCount = 1;
            //tackling the update method
            //if it is called once per frame, then solvedCount will be updated once per frame
            //TESTING 

            if(update_pts_once == 1)
            {
                onPuzzleComplete?.Invoke(solvedCount);
                update_pts_once = 0; //aimed at updating the points only once
            }

        }
        else
        {
            //TODO: Needs a logic for negative marking if the puzzle pieces move away from targets
            puzzlePlacementObj.GetComponent<Renderer>().material.color = Color.grey;
        }
        
    }
}
