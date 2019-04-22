using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBlockPuzzleController : MonoBehaviour
{

    public float tolerance;
    private GameObject mBrownBlock;
    private GameObject mBlueBlock;
    private GameObject mYellowBlock;
    private GameObject mGreenBlock;
    private float mBrownHeight;

    // Start is called before the first frame update
    void Start()
    {
        mBrownBlock = transform.Find("BrownBlock").gameObject;
        mBlueBlock = transform.Find("BlueBlock").gameObject;
        mGreenBlock = transform.Find("GreenBlock").gameObject;
        mYellowBlock = transform.Find("YellowBlock").gameObject;
        mBrownHeight = mBrownBlock.GetComponent<Renderer>().bounds.size.y;

    }

    // Return true if yellow block is on top of brown block
    bool IsSolved()
    {
        Vector3 YellowPosition = mYellowBlock.transform.position;
        Vector3 BrownPosition = mBrownBlock.transform.position;
        if (YellowPosition.y > BrownPosition.y
        && (YellowPosition.y - BrownPosition.y) < mBrownHeight + tolerance
        && Mathf.Abs(YellowPosition.x - BrownPosition.x) < tolerance
        && Mathf.Abs(YellowPosition.z - BrownPosition.z) < tolerance)
        {
            // Yellow block, green block, blue block on top of brown block
            return true;
        }
        return false;
    }
    void Update()
    {
        if (IsSolved() == true)
        {
            // Puzzle has been solved. Turn blocks white.
            mBrownBlock.GetComponent<Renderer>().material.color = Color.white;
            mBlueBlock.GetComponent<Renderer>().material.color = Color.white;
            mGreenBlock.GetComponent<Renderer>().material.color = Color.white;
            mYellowBlock.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}