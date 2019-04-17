using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialBlockController : MonoBehaviour //added to dials
{
    public float unitsPerDegree = 0.001f;

    private GameObject mDial1;
    private GameObject mDial2;

    private GameObject mController;
    private GameObject mBase;
    private GameObject mPuzPiece;

    private Vector3 mPrevDialRotation1;
    private Vector3 mPrevDialRotation2;


    public int PieceNumber;

    //Index for the dials
    public int DialNumber1;
    public int DialNumber2;

    //moving along an arbitrary axis
    public Vector3 axis1 = Vector3.up;
    public Vector3 axis2 = Vector3.up;


    // Start is called before the first frame update
    void Start()
    {
        mPuzPiece = GameObject.FindGameObjectWithTag("puzpiece" + PieceNumber).gameObject;
        mController = GameObject.FindGameObjectWithTag("controller" + PieceNumber).gameObject;
        mBase = mController.transform.Find("Base").gameObject;

        mDial1 = mBase.transform.Find("Dial" + DialNumber1).gameObject; //Testing
        mDial2 = mBase.transform.Find("Dial" + DialNumber2).gameObject; //Testing

        //getting both dials
        mPrevDialRotation1 = mDial1.transform.localEulerAngles;
        mPrevDialRotation2 = mDial2.transform.localEulerAngles;


    }

    /**
     * (If works)
     * Instead of adding same code for both dials, create a method
     * void MoveAround(dial, axis) for better code
     **/

    // Update is called once per frame
    void Update()
    {
        Vector3 curDialRotation1 = mDial1.transform.localEulerAngles; //Testing
        Vector3 curDialRotation2 = mDial2.transform.localEulerAngles;

        if (curDialRotation1 != mPrevDialRotation1)
        {
            float dialRotation1 = curDialRotation1.y - mPrevDialRotation1.y;
       
        if (mPrevDialRotation1.y > 270 && curDialRotation1.y < 90)
            {
                dialRotation1 += 360;
            }
            else if (mPrevDialRotation1.y < 90 && curDialRotation1.y > 270)
            {
                dialRotation1 -= 360;
            }      
            
        

        float blockMoveDist1 = unitsPerDegree * dialRotation1;

        mPuzPiece.transform.Translate(axis1 * blockMoveDist1);
        mPrevDialRotation1 = curDialRotation1;

        }
        if (curDialRotation2 != mPrevDialRotation2)
        {
            float dialRotation2 = curDialRotation2.y - mPrevDialRotation2.y;
       

        if (mPrevDialRotation2.y > 270 && curDialRotation2.y < 90)
            {
                dialRotation2 += 360;
            }
            else if (mPrevDialRotation2.y < 90 && curDialRotation2.y > 270)
            {
                dialRotation2 -= 360;
            }

           

            float blockMoveDist2 = unitsPerDegree * dialRotation2;

            mPuzPiece.transform.Translate(axis2 * blockMoveDist2);
            mPrevDialRotation2 = curDialRotation2;

        }

    }
}
