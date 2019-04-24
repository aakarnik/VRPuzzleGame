using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Controller : MonoBehaviour
{



    //Base of the puzzle
    private GameObject BlockPlacers;
    //TODO: Create one private GameObject variable named "puzzle1block"
    private GameObject puzzle1block;

    /** TODO: Create one public int variable named "blockNum" to store the number of the block number 
              This will be helpful to retrieve each block */

    public int blockNum = 1;

    //tolerance should allow the player to win when the piece is within a certain area of the placer
    //set to the number of units the piece moves along both axis

    public float xTolerance = 0.001f;
    public float yTolerance = .05f;
    public float zTolerance = .05f;

    //color
    //private Color blockColor;





    // Start is called before the first frame update
    void Start()
    {
        BlockPlacers = GameObject.FindGameObjectWithTag("grey" + blockNum).gameObject;
        puzzle1block = GameObject.FindGameObjectWithTag("block" + blockNum).gameObject;

        //Retrieve block color
        //blockColor = puzzle1block.Shader.Find("_color");

    }

    // Return true if yellow block is on top of brown block
    bool IsSolved()
    {
        /** TODO: Create a Vector3 variable name "BlockPosition"
         *        Store the position of the "puzzle1block" in it (just like BrownPosition)
         */

        Vector3 BlockPosition = puzzle1block.transform.position;
        Vector3 BlockplacerPosition = BlockPlacers.transform.position;

        /** TODO: Complete the if-statement below
         *        Use "BlockPosition" instead of "YellowPosition"
         *        Now the code should work for all blocks instead of just the Yellow Block
         */


        if ((BlockPosition.y >= BlockplacerPosition.y + yTolerance) &&
                BlockPosition.x < (BlockplacerPosition.x + xTolerance) && BlockPosition.x > (BlockplacerPosition.x - xTolerance) &&
                BlockPosition.z < (BlockplacerPosition.z + zTolerance) && BlockPosition.z > (BlockplacerPosition.z - zTolerance))
        {
            return true;
        }

        return false;
    }


    void Update()
    {
        if (IsSolved() == true)
        {
            // Puzzle has been solved. Turn blocks white.

            //TODO: Change the color of the "Puzzle1Block" to white
            BlockPlacers.GetComponent<Renderer>().material.color = Color.white;

        }

        else
        {
            BlockPlacers.GetComponent<Renderer>().material.color = Color.grey;
        }

    }
}
