using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Controller : MonoBehaviour
{

    //The height at which the blocks can rest on the base 
    public float tolerance;

    //Base of the puzzle
    private GameObject mBrownBlock;

    //TODO: Create one private GameObject variable named "puzzle1block"


    /** TODO: Create one public int variable named "blockNum" to store the number of the block number 
               This will be helpful to retrieve each block */




    private float mBrownHeight;

    // Start is called before the first frame update
    void Start()
    {
     /** TODO: Assign a tag name to the BrownBlock in Unity 
               Set "mBrownBlock" equal to the object with the Brownblock tag  
              (see PuzzlePlacer.cs line 22 for reference) */



     /** TODO: Assign a consistent numbered tag to every puzzle block for Puzzle 1 (block1, block2, block3, etc.)
               Set "puzzle1block" equal to the object with the tag string and the "blockNum" variable 
              (see PuzzlePlacer.cs line 23 for reference)*/




        
        mBrownHeight = mBrownBlock.GetComponent<Renderer>().bounds.size.y; 

    }

    // Return true if yellow block is on top of brown block
    bool IsSolved()
    {
        /** TODO: Create a Vector3 variable name "BlockPosition"
         *        Store the position of the "puzzle1block" in it (just like BrownPosition)
         */

        //Storing the position of the Brown Base Block
        Vector3 BrownPosition = mBrownBlock.transform.position;

        /** TODO: Complete the if-statement below
         *        Use "BlockPosition" instead of "YellowPosition"
         *        Now the code should work for all blocks instead of just the Yellow Block
         */

        //if (YellowPosition.y > BrownPosition.y
        //&& (YellowPosition.y - BrownPosition.y) < mBrownHeight + tolerance
        //&& Mathf.Abs(YellowPosition.x - BrownPosition.x) < tolerance
        //&& Mathf.Abs(YellowPosition.z - BrownPosition.z) < tolerance)
        //{
               //return true;
         // }



        //currently the function will only return false
        return false;
    }
    void Update()
    {
        if (IsSolved() == true)
        {
            // Puzzle has been solved. Turn blocks white.


            /*TODO: Change the color of the "Puzzle1Block" to white
                    Puzzle1Block.GetComponent<Renderer>().material.color = Color.white;*/

        }

        // Add this script to the BrownBlock
        // Test on Oculus to see if this functions so far
    }
}
 