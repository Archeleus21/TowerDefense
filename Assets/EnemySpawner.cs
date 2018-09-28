using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyMovement enemy;  //using EnemyMoovement instead of GameObject so only gameobjects with an EnemyMovement component can be used

    float enemySpawnTimer = 2f;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(enemySpawnTimer);
        }
    }    
}
