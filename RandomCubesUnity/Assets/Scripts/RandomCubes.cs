/****
* Created by: Betzaida Ortiz Rivas
* Date Created: Jan 24, 2022
* Last Edited by: nameof
* Last Edited: Jan 26, 2022
* 
* Description: Spawn random cubes
* 
* ****/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    public GameObject cubePrefab; //new GameObject
    public float scalingFactor = 0.95f; // amount each cube will shrink each frame
    public int numberOfCubes = 0; // total number of cubes instantiated

    [HideInInspector]
    public List<GameObject> gameObjectList; // list for all cubes

    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instantiate the list
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; // add number of cubes

        GameObject gObj = Instantiate<GameObject>(cubePrefab); //create cube instance

        gObj.name = "Cube" + numberOfCubes; //name of cube instance

        Color randColor = new Color(Random.value, Random.value, Random.value); //creates new random color

        gObj.GetComponent<Renderer>().material.color = randColor; //assigns random color to game object

        gObj.transform.position = Random.insideUnitSphere; // random location inside a sphere radius pf 1 out from 0,0,0

        gameObjectList.Add(gObj); //add to list

        List<GameObject> removeList = new List<GameObject>(); //list for removed objects

        foreach(GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x; //records current scale
            scale *= scalingFactor; // scale multiplied by scale factor
            goTemp.transform.localScale = Vector3.one * scale; // transform scale
            Debug.Log(goTemp.transform.localScale); // debugs
            if (scale <= 0.1f)
            {
                removeList.Add(goTemp);
            } // end  if(scale <= 0.1f)
        } // end foreach(GameObject goTemp in gameObjectList)

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); // remove from game object list
            Destroy(goTemp); // destroys game object
       
        }//end foreach(GameObject goTemp in removeList)

        Debug.Log(removeList.Count); // debugs remove list
    }
}
