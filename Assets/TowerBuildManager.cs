using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildManager : MonoBehaviour
{
    public GameObject towerPrefab;
    GameObject towerParent;

	// Use this for initialization
	void Start ()
    {
        towerParent = GameObject.Find("Towers");
    }
	
    public void PlaceATower(Vector3 blockPos)
    {
        Instantiate(towerPrefab, blockPos, Quaternion.identity, towerParent.transform);
    }

}
