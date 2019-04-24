using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Spawner : MonoBehaviour
{
    // contains the object we want to spawn - for example, a key or a dialcontroller
    public GameObject objectToSpawn;

    //contains the spawner object which will be used to find where to create an instance of the "objectToSpawn"
    public GameObject objectSpawner;

    //hard coding to 4 for puzzle 2
    //TESTING
    public int requiredPlacements = 4;

    //storing the count for how many pieces are/were in the right place
    private int totalPlaced = 0;
    
    //currently, if the player dismantles the puzzle after putting the pieces
    //in the right place, points will still be counted
    //there will be no negative marking

    void SpawnObject(int pts)
    {
        totalPlaced += pts;

        if (totalPlaced > requiredPlacements)
        {
            GameObject newObject = Instantiate(objectToSpawn.gameObject, transform);
            newObject.transform.Translate(objectSpawner.transform.position);
        }
    }

    private void OnEnable()
    {
        //Testing
        PuzzlePlacer.onPuzzleComplete += SpawnObject;
    }

    private void OnDisable()
    {
        //Testing
        PuzzlePlacer.onPuzzleComplete -= SpawnObject;
    }

}
