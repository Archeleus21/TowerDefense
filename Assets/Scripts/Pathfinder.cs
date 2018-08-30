using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint finishWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();  //creates a "dictionary"(datastructure)
                                                                                     //to store grid points/waypoints
    Queue<Waypoint> queue = new Queue<Waypoint>();  //creates empty queue

    bool isRunning = true;

    //used to start to get coordinates around a waypoint in said directions
    Vector2Int[] directions =
    {
        //new Vector2Int(0,1), //up
        //new Vector2Int(1,0), //right
        //new Vector2Int(0,-1), //down
        //new Vector2Int(-1,0) //left
        //same as this:
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Use this for initialization
    void Start ()
    {
        LoadBlocks();
        SetStartAndFinishColors();
        Pathfind();
        //ExploreNeighbors();
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            Waypoint searchCenter = queue.Dequeue();
            print("Searching: " + searchCenter);
            HaltIfEndFound(searchCenter);

            ExploreNeighbors(searchCenter);
            searchCenter.isExplored = true;
        }
        print("Finished Pathfinding?");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if(searchCenter == finishWaypoint)
        {
            print("Found Finish Waypoint");
            isRunning = false;
        }
    }

    //uses the specified starting point and adds "directions" to waypoints to look at nearby blocks
    private void ExploreNeighbors(Waypoint from)
    {
        if (!isRunning) { return; }
         
        foreach (Vector2Int direction in directions)
        {
            Vector2Int lookAtNeighbors = from.GetGridPosition() + direction;  //takes starting spot and adds "directions"
            try
            {
                QueueNewNeighbors(lookAtNeighbors);
            }
            catch
            {
                //do nothing
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int lookAtNeighbors)
    {
        Waypoint neighbor = grid[lookAtNeighbors];

        if (neighbor.isExplored)
        {
            //do nothing
        }
        else
        {
            neighbor.SetColorCubeTop(Color.grey);  //sets color to nearby blocks
            queue.Enqueue(neighbor);

            print("queing: " + neighbor);
        }

    }

    private void SetStartAndFinishColors() //sets starting and finishing colors
    {
        startWaypoint.SetColorCubeTop(Color.green);  //set starting color
        finishWaypoint.SetColorCubeTop(Color.red);  //set finish color
    }

    private void LoadBlocks()  //loads waypoints into dictionary
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
