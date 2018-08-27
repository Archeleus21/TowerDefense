using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint finishWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

	// Use this for initialization
	void Start ()
    {
        LoadBlocks();
        SetStartAndFinishColors();
    }

    private void SetStartAndFinishColors()
    {
        startWaypoint.SetColorCubeTop(Color.green);  //set starting color
        finishWaypoint.SetColorCubeTop(Color.red);  //set finish color
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();  //creates an array for the gridpoints/waypoints

        foreach (Waypoint waypoint in waypoints)  //looks for each waypoint in the array
        {
            Vector2Int gridPos = waypoint.GetGridPosition();  //stores the position of each waypoint from waypoint script
            if (grid.ContainsKey(gridPos))  //checks dictionary for duplicate/overlapping waypoints
            {
                //overlapping blocks?
                Debug.LogWarning("block overlapping at: " + waypoint);  //prints warning of overlapping
            }
            else
            {
                //add to dictionary if not
                grid.Add(waypoint.GetGridPosition(), waypoint);  //add block to dictionary if not overlapping
            }
        }
    }
}
