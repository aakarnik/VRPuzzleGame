using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialBlockController : MonoBehaviour
{
    public float unitsPerDegree = 0.001f;
    private GameObject mDial;
    private GameObject mPuzPiece;
    private Vector3 mPrevDialRotation;

    //moving along an arbitrary axis
    public Vector3 axis = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        mPuzPiece = GameObject.FindGameObjectWithTag("puzpiece" + 1).gameObject; //testing
        GameObject handController = transform.Find("HandController").gameObject;
        GameObject controllerBase = handController.transform.Find("Base").gameObject;
        mDial = controllerBase.transform.Find("Dial").gameObject;
        mPrevDialRotation = mDial.transform.localEulerAngles;



    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curDialRotation = mDial.transform.localEulerAngles;
        if (curDialRotation != mPrevDialRotation)
        {
            float dialRotation = curDialRotation.y - mPrevDialRotation.y;
            float blockMoveDist = unitsPerDegree * dialRotation;

            // move the block
            //mPuzPiece.transform.Translate(new Vector3(0, blockMoveDist, 0));

            mPuzPiece.transform.Translate(axis * blockMoveDist);
            mPrevDialRotation = curDialRotation;
            

        }
    }
}
