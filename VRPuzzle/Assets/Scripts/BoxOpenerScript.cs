using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpenerScript : MonoBehaviour
{
    //Getting the lid of the box
    GameObject Lid;

    //moving the lid
    Vector3 Lid_pos;
    Vector3 keyplacer_pos;
    Vector3 key_pos;
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
    private float xTolerance = .01f;
    private float yTolerance = .001f;
    private float zTolerance = .01f;

    // Start is called before the first frame update
    void Start()
    {
        key_placer = GameObject.FindGameObjectWithTag("key_placer").gameObject;
       
        keyplacer_pos = key_placer.transform.position;
        key_pos = key_obj.transform.position;

        Lid = GameObject.FindGameObjectWithTag("Slider1").gameObject;

        FinalObject = GameObject.FindGameObjectWithTag("Final_Win").gameObject;
        FinalObject.SetActive(false);
    
    }
    bool isSolved()
    {
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
        if (isSolved() == true)
        {
            FinalObject.SetActive(true);
            Lid.SetActive(false);
            key_obj.SetActive(false);
        }
    }
}
