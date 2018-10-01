using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EnemyHealth enemyHealth;

    void Start()
    {
        //StartCoroutine(PrintAllWaypoints());  //must use StartCoroutine() in order to call methods / coroutines
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        enemyHealth = FindObjectOfType<EnemyHealth>() as EnemyHealth;
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
        enemyHealth.DamageBase(new Vector3(transform.position.x, transform.position.y + 5, transform.position.z)); 
    }
}
