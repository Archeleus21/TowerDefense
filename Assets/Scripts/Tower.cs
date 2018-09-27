using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform partToPivot;  //used to rotate top
    [SerializeField] Transform targetEnemy;  //used to look at the enemy
    
	
	// Update is called once per frame
	void Update ()
    {
        partToPivot.LookAt(targetEnemy);
	}
}
