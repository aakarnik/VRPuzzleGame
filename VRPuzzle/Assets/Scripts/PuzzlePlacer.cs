using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePlacer : MonoBehaviour
{
    private GameObject puzzlePlacementObj;
    private GameObject puzzlePiece;

    public int PieceNumber = 1;

    public float xDistance = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
     puzzlePlacementObj = GameObject.FindGameObjectWithTag("placer" + PieceNumber).gameObject;
     puzzlePiece = GameObject.FindGameObjectWithTag("puzpiece" + PieceNumber).gameObject;
     
    }

    bool isSolved()
    {
        Vector3 piecePosition = puzzlePiece.transform.position;
        Vector3 placePosition = puzzlePlacementObj.transform.position;

        if((piecePosition.x >= placePosition.x + xDistance) &&
                piecePosition.y == placePosition.y &&
                piecePosition.z == placePosition.z) {
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
