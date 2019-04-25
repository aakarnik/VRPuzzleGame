using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleComplete2 : MonoBehaviour
{
    //Contains the reference of the Key or the Dial
    public GameObject NextLevelKey;

    //the count variable stores the number of pieces arranged
    public Puzzle2Controller[] PuzzlePieces;

    //checking if the puzzle is solved or not
    private bool isPuzzleSolved;

    // Start is called before the first frame update
    void Start()
    {
        //The key object is visible before the puzzle is solved
        NextLevelKey.SetActive(true);
        //isPuzzleSolved = true;
    }


    void Update()
    {
        isPuzzleSolved = true;

        for (int i = 0; i < PuzzlePieces.Length; i++)
        {
            if (PuzzlePieces[i].IsSolved() == false)
            {
                isPuzzleSolved = false;
            }
        }

        if (isPuzzleSolved == true)
        {
            NextLevelKey.SetActive(false);
        }

        //NextLevelKey.SetActive(false);
    }
}

