using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    void Start()
    {
        //StartCoroutine(PrintAllWaypoints());  //must use StartCoroutine() in order to call methods / coroutines
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

	void Update()
    {

    }

    IEnumerator FollowPath(List<Waypoint> path)  //IEnumerator returns a value and creates a co-routine
    {
        print("Starting Patrol");
        foreach (Waypoint cubeWaypoint in path)
        {
            transform.position = cubeWaypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("Ending Patrol");
    }

}
