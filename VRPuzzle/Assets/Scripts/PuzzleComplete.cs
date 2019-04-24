using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleComplete : MonoBehaviour
{
    //Contains the reference of the Key or the Dial
    public GameObject NextLevelKey;

    //the count variable stores the number of pieces arranged
    public PuzzlePlacer[] PuzzlePieces;

    //checking if the puzzle is solved or not
    private bool isPuzzleSolved;

    // Start is called before the first frame update
    void Start()
    {
        //The key object is invisible before the puzzle is solved
        NextLevelKey.SetActive(false);
        //isPuzzleSolved = true;
    }

    
    void Update()
    {
        isPuzzleSolved = true;
        for(int i = 0; i < PuzzlePieces.Length; i++)
        {
            if(PuzzlePieces[i].isSolved() == false)
            {
                isPuzzleSolved = false;
            }
        }

        if (isPuzzleSolved == true)
        {
            NextLevelKey.SetActive(true);
        }

        //NextLevelKey.SetActive(false);
    }
}
