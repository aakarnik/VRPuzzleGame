using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialBlockController : MonoBehaviour //added to dials
{
    public float unitsPerDegree = 0.001f;
    private GameObject mDial;
    private GameObject mController;
    private GameObject mPuzPiece;
    private Vector3 mPrevDialRotation;

    public int PieceNumber;
    public int DialNumber;
    //moving along an arbitrary axis
    public Vector3 axis = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        mPuzPiece = GameObject.FindGameObjectWithTag("puzpiece" + PieceNumber).gameObject; //WORKED
        mController = GameObject.FindGameObjectWithTag("controller" + PieceNumber).gameObject;
        //mDial = mController.FindGameObjectWithTag("Dial" + DialNumber).gameObject; //WORKED
        mDial = mController.transform.Find("Dial" + DialNumber).gameObject; //Testing
        mPrevDialRotation = mDial.transform.localEulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curDialRotation = mDial.transform.localEulerAngles;
        if (curDialRotation != mPrevDialRotation)
        {
            float dialRotation = curDialRotation.y - mPrevDialRotation.y;
           

            // move the block
            //mPuzPiece.transform.Translate(new Vector3(0, blockMoveDist, 0));

            if (mPrevDialRotation.y > 270 && curDialRotation.y < 90)
            {
                dialRotation += 360;
            }
            else if (mPrevDialRotation.y < 90 && curDialRotation.y > 270)
            {
                dialRotation -= 360;
            }

            float blockMoveDist = unitsPerDegree * dialRotation;
            mPuzPiece.transform.Translate(axis * blockMoveDist);
            mPrevDialRotation = curDialRotation;            


        }
    }
}
