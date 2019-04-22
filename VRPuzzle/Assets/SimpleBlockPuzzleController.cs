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
    private float mBlueHeight;

    // Start is called before the first frame update
    void Start()
    {
        mBrownBlock = transform.Find("BrownBlock").gameObject;
        mBlueBlock = transform.Find("BlueBlock").gameObject;
        mGreenBlock = transform.Find("BlueBlock").gameObject;
        mBlueHeight = mBlueBlock.GetComponent<Renderer>().bounds.size.y;

    }

    // Return true if puzzle is solved.
    bool IsSolved()
    {
        Vector3 RedPosition = mBrownBlock.transform.position;
        Vector3 BluePosition = mBlueBlock.transform.position;
        if (RedPosition.y > BluePosition.y
        && (RedPosition.y - BluePosition.y) < mBlueHeight + tolerance
        && Mathf.Abs(RedPosition.x - BluePosition.x) < tolerance
        && Mathf.Abs(RedPosition.z - BluePosition.z) < tolerance)
        {
            // Red block on top of blue block
            return true;
        }
        return false;
    }
    void Update()
    {
        if (IsSolved() == true)
        {
            // Puzzle has been solved. Turn blocks yellow.
            mBrownBlock.GetComponent<Renderer>().material.color = Color.yellow;
            mBlueBlock.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}