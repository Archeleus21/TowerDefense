using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyMovement enemy;  //using EnemyMovement instead of GameObject so only gameobjects with an EnemyMovement component can be used
    Transform enemyParent;
    SoundManager soundManager;

    public int enemyCount = 0;
    float enemySpawnTimer = 2f;

	// Use this for initialization
	void Start ()
    {
        enemyParent = GameObject.Find("Enemies").transform;
        soundManager = FindObjectOfType<SoundManager>() as SoundManager;
        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemy, transform.position, Quaternion.Euler(0f,90f,0f), enemyParent.transform);
            enemyCount++;
            soundManager.PlayEnemySpawnSound();
            yield return new WaitForSeconds(enemySpawnTimer);
        }
    }    
}
