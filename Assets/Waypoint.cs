using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;

    const int gridSize = 10;

    // Use this for initialization
    void Start () {
		
	}
	
    public int GetGridSize()  //public so other scripts can access this method/function
    {
        return gridSize; 
    }

    public Vector2Int GetGridPosition()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize) * gridSize, 
                              Mathf.RoundToInt(transform.position.z / gridSize) * gridSize); 
                              //creates a value, divides by 10 and rounds to nearest 
                              //whole number, then times 10 for unit movement
    }

	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetColorCubeTop(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
