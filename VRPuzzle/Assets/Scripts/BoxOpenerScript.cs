using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpenerScript : MonoBehaviour
{
    //Getting the lid of the box
    GameObject Lid;

    //moving the lid
    Vector3 Lid_pos;
    //public float lid_speed;
    //public float min_dist;

    //check if the puzzle is solved
    bool isOpened;

    //Object Inside the Box
    GameObject FinalObject;

    //Key and key placer
    GameObject key_placer;
    public GameObject key_obj;

    //tolerance
    public float xTolerance = 0.001f;
    public float yTolerance = .005f;
    public float zTolerance = .005f;

    // Start is called before the first frame update
    void Start()
    {
        key_placer = GameObject.FindGameObjectWithTag("key_placer").gameObject;
        //key_obj = GameObject.FindGameObjectWithTag("Final_Key").gameObject;

        Lid = GameObject.FindGameObjectWithTag("Slider1").gameObject;

        FinalObject = GameObject.FindGameObjectWithTag("Final_Win").gameObject;
        FinalObject.SetActive(false);
    
    }
    bool isSolved()
    {
        Vector3 key_pos = key_obj.transform.position;
        Vector3 keyplacer_pos = key_placer.transform.position;

        Lid_pos = Lid.transform.position;

        if ((key_pos.y >= keyplacer_pos.y + yTolerance) &&
                key_pos.x < (keyplacer_pos.x + xTolerance) && key_pos.x > (keyplacer_pos.x - xTolerance) &&
                key_pos.z < (keyplacer_pos.z + zTolerance) && key_pos.z > (keyplacer_pos.z - zTolerance))
        {
            return true;
        }

        return false;


    }
    // Update is called once per frame
    void Update()
    {
        //float changeInPos = Time.deltaTime * lid_speed;
       //Vector3 posOffset = new Vector3(changeInPos, 0, 0);

        if (isSolved() == true)
        {
            FinalObject.SetActive(true);
            Lid.SetActive(false);
            key_obj.SetActive(false);
        }
    }
}
