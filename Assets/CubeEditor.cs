using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]  //updates in editor mode instead of having to play the game
[SelectionBase]  //selects base object and not children
public class CubeEditor : MonoBehaviour {

   
    [SerializeField] [Range(0f, 100f)] float gridSize = 10f;

    TextMesh textMesh;


    // Update is called once per frame
    void Update ()
    {

        Vector3 snapPosition; //this creates a new vector used for gameObjects position
        snapPosition.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;  //creates the X value, divides by 10 and rounds to nearest 
                                                                              //whole number, then times 10 for unit movement
        snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize; //creates the Z value, divides by 10 and rounds to nearest 
                                                                             //whole number, then times 10 for unit movement
        transform.position = new Vector3(snapPosition.x, 0f, snapPosition.z);  //takes gameObjects pos and uses variables to create new values

        textMesh = GetComponentInChildren<TextMesh>();
        string cubeLabel = snapPosition.x / gridSize + "," + snapPosition.z / gridSize;
        gameObject.name = cubeLabel;
	}
}
