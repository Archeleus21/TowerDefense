using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] List<Waypoint> path;
    
    void Start()
    {
        //StartCoroutine(PrintAllWaypoints());  //must use StartCoroutine() in order to call methods / coroutines
    }

	void Update()
    {

    }

    IEnumerator PrintAllWaypoints()  //IEnumerator returns a value and creates a co-routine
    {
        print("Starting Patrol");
        foreach (Waypoint cubeWaypoint in path)
        {
            transform.position = cubeWaypoint.transform.position;
            print("Visiting Block: " + cubeWaypoint.name);
            yield return new WaitForSeconds(1f);
        }
        print("Ending Patrol");
    }

}
