using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyMovement enemy;  //using EnemyMovement instead of GameObject so only gameobjects with an EnemyMovement component can be used
    GameObject enemyParent;

    float enemySpawnTimer = 2f;

	// Use this for initialization
	void Start ()
    {
        enemyParent = GameObject.Find("Enemies");
        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemy, transform.position, Quaternion.identity, enemyParent.transform);

            yield return new WaitForSeconds(enemySpawnTimer);
        }
    }    
}
