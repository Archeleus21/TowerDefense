using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]  //updates in editor mode instead of having to play the game
[SelectionBase]  //selects base object and not children
[RequireComponent(typeof (Waypoint))]  //used to always look for waypoint script

public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;  //used as instance of waypoint script

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();  //used to access script

    }

    // Update is called once per frame
    void Update ()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();  //gets gridSize from waypoint script
        transform.position = new Vector3(waypoint.GetGridPosition().x * gridSize,
                                         0f, 
                                         waypoint.GetGridPosition().y * gridSize);  //takes gameObjects pos and uses variables to create new values
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string cubeLabel = waypoint.GetGridPosition().x + "," + waypoint.GetGridPosition().y;
        textMesh.text = cubeLabel;
        gameObject.name = cubeLabel;
    }
}
