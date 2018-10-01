using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildManager : MonoBehaviour
{
    public Tower towerPrefab;

    GameObject towerParent;

    int towerLimit = 5;

    Queue<Tower> towerQueue = new Queue<Tower>();  //creates an empty queue


	// Use this for initialization
	void Start ()
    {
        towerParent = GameObject.Find("Towers");
    }

    public void PlaceATower(Waypoint baseWaypoint)
    {
        if (towerLimit > 0)
        {
            Tower towerPrefabGO = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity, towerParent.transform); //stores instantiated GameObject
            baseWaypoint.isAbleToBuild = false;
            towerLimit--;  //subtracts the limit 

            towerPrefab.baseWaypoint = baseWaypoint;
            baseWaypoint.isAbleToBuild = false;
            AddTowerToQueue(towerPrefabGO);
        }
        else
        {
            MoveExitingTower(baseWaypoint);
        }
    }

    void AddTowerToQueue(Tower towerPrefab)
    {
        if (towerLimit >= 0)
        {
            towerQueue.Enqueue(towerPrefab);
        }

        print("Towers in queue " + towerQueue.Count.ToString());
    }

     void MoveExitingTower(Waypoint newBaseWaypoint)
    {
        Tower firstItemQueued = towerQueue.Dequeue();  //gets first item placed in queue
        Tower lastItemQueued = towerQueue.Peek();  //looks at last item or top item in queue

        firstItemQueued.baseWaypoint.isAbleToBuild = true;  //allows building of new tower on this block/waypoint
        newBaseWaypoint.isAbleToBuild = false;

        firstItemQueued.baseWaypoint = newBaseWaypoint;
        firstItemQueued.transform.position = newBaseWaypoint.transform.position;

        towerQueue.Enqueue(firstItemQueued);  //puts firstItemQueued at the top of the list/queue
        //firstItemQueued = blockPos;  //moves firstitem to the new block on the level
    }
}
