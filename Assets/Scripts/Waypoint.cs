﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    TowerBuildManager towerBuildManager;
    Waypoint baseWaypoint;

    [SerializeField] Color exploredColor;

    Vector3 blockPos;
    Vector2Int gridPos;

    public Waypoint exploredFrom;
    public bool isExplored = false;  //ok as is a data class
    public bool isAbleToBuild = true;  //checks if block is empty

    const int gridSize = 10;

    private void Start()
    {
        towerBuildManager = FindObjectOfType<TowerBuildManager>() as TowerBuildManager;
    }
	
    public int GetGridSize()  //public so other scripts can access this method/function
    {
        return gridSize; 
    }

    public Vector2Int GetGridPosition()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize), 
                              Mathf.RoundToInt(transform.position.z / gridSize)); 
                              //creates a value, divides by 10 and rounds to nearest 
                              //whole number, then times 10 for unit movement
    }

    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (isAbleToBuild)
            {
                towerBuildManager.PlaceATower(this);
                isAbleToBuild = false;
                Debug.Log("Build Tower Here!");             
            }
            else
            {
                Debug.Log("Cannot Build Here!");
            }
        }
    }
}
