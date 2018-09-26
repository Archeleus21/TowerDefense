using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;
    Vector2Int gridPos;

    public Waypoint exploredFrom;
    public bool isExplored = false;  //ok as is a data class

    const int gridSize = 10;

    private void Start()
    {
        //exploredColor = Color.gray;
    }

    // Use this for initialization
    void Update ()
    {
        //if (isExplored == true )
        //{
        //    SetColorCubeTop(exploredColor);
        //}
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

    public void SetColorCubeTop(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
