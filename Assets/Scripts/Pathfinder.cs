using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    public Waypoint startWaypoint;
    public Waypoint finishWaypoint;

    List<Waypoint> path = new List<Waypoint>();  //used for storing path from finish to start

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();  //creates a "dictionary"(datastructure)
                                                                                     //to store grid points/waypoints
    Queue<Waypoint> queue = new Queue<Waypoint>();  //creates empty queue

    bool isRunning = true;

    Waypoint searchCenter;  //current Search point

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

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }

        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        path.Add(finishWaypoint);  //adds finish waypoint to list

        Waypoint previous = finishWaypoint.exploredFrom;  //stores the previous block that led to the finish block
        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }


        path.Add(startWaypoint);  //adds start waypoint to the end of the list
        path.Reverse();  //reverses the list

        BlockPathFromBuilding();
    }

    //checks all waypoints that were added to the list and marks them as unbuildable
    private void BlockPathFromBuilding()
    {
        foreach (Waypoint paths in path)
        {
            paths.isAbleToBuild = false;
        }
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();

            ExploreNeighbors();
            searchCenter.isExplored = true;
        }
    }

    private void HaltIfEndFound()
    {
        if(searchCenter == finishWaypoint)
        {
            isRunning = false;
        }
    }

    //uses the specified starting point and adds "directions" to waypoints to look at nearby blocks
    private void ExploreNeighbors()
    {
        if (!isRunning) { return; }
         
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborsCoordinates = searchCenter.GetGridPosition() + direction;  //takes starting spot and adds "directions"
            if(grid.ContainsKey(neighborsCoordinates))
            {
                QueueNewNeighbors(neighborsCoordinates);
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int lookAtNeighbors)
    {
        Waypoint neighbor = grid[lookAtNeighbors];

        if (neighbor.isExplored || queue.Contains(neighbor))
        {
            //do nothing
        }
        else
        {
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = searchCenter;
        }
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
