using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Controller : MonoBehaviour
{

    //The height at which the blocks can rest on the base 
    public float tolerance;

    //Base of the puzzle
    private GameObject mBrownBlock;

    //x position
    public float xconstraint1;
    public float xconstraint2;

    //y position
    public float zconstraint1;
    public float zconstraint2;

    //color
    private Color blockColor;

    //TODO: Create one private GameObject variable named "puzzle1block"
    private GameObject puzzle1block;

    /** TODO: Create one public int variable named "blockNum" to store the number of the block number 
               This will be helpful to retrieve each block */

    public int blockNum = 0;

    private float mBrownHeight;

    // Start is called before the first frame update
    void Start()
    {
        /** TODO: Assign a tag name to the BrownBlock in Unity 
                  Set "mBrownBlock" equal to the object with the Brownblock tag  
                 (see PuzzlePlacer.cs line 22 for reference) */
        mBrownBlock = GameObject.FindGameObjectWithTag("mBrownBlock").gameObject;

        /** TODO: Assign a consistent numbered tag to every puzzle block for Puzzle 1 (block1, block2, block3, etc.)
                  Set "puzzle1block" equal to the object with the tag string and the "blockNum" variable 
                 (see PuzzlePlacer.cs line 23 for reference)*/
        puzzle1block = GameObject.FindGameObjectWithTag("block" + blockNum).gameObject;

        mBrownHeight = mBrownBlock.GetComponent<Renderer>().bounds.size.y;

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

        //Storing the position of the Brown Base Block
        Vector3 BrownPosition = mBrownBlock.transform.position;

        /** TODO: Complete the if-statement below
         *        Use "BlockPosition" instead of "YellowPosition"
         *        Now the code should work for all blocks instead of just the Yellow Block
         */

        if ((BlockPosition.y >= BrownPosition.y + mBrownHeight) &&
                 BlockPosition.x < (BrownPosition.x + xconstraint1 ) && BlockPosition.x > (BrownPosition.x - xconstraint2) &&
                 BlockPosition.z < (BrownPosition.z + zconstraint1 ) && BlockPosition.z > (BrownPosition.z - zconstraint2 ))
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
            puzzle1block.GetComponent<Renderer>().material.color = Color.white;

        }

       // else {

            //puzzle1block.GetComponent<Renderer>().material.color = blockColor;

        //}

        // Add this script to the all blocks
        // Test on Oculus to see if this functions so far
    }
}
 