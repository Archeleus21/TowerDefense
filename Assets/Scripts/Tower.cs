using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    GameObject enemy;
    EnemyHealth enemyHealth;

    [SerializeField] Transform partToPivot;  //used to rotate top
    [SerializeField] Transform targetEnemy;  //used to look at the enemy
    [SerializeField] Transform firePoint;  //firing position
    [SerializeField] ParticleSystem towerBullets; //used to store bullet particle

    float fireRate = .5f;
    public bool isShooting;

    private void Start()
    {
        enemy = GameObject.Find("Enemy");  //instance of object reference
        enemyHealth = enemy.GetComponent<EnemyHealth>();  //gets script from object that was referenced
        towerBullets = GetComponentInChildren<ParticleSystem>();  //gets particlesystem

        StartCoroutine(towerShooting(enemyHealth.GetIsEnemyAlive()));  //starts coroutine to fire
    }

    // Update is called once per frame
    void Update ()
    {
        partToPivot.LookAt(targetEnemy);  //used to track the enemy
        
	}

    IEnumerator towerShooting(bool isEnemyAlive)  //used to shoot at the enemy as long as the enemy is alive
    {

        while (isEnemyAlive) //runs while enemy is alive
        {
            towerBullets.Play();  //shoots bullets
            yield return new WaitForSeconds(fireRate);  //pauses to control firing speed
            towerBullets.Stop();  //stops shooting
            isEnemyAlive = enemyHealth.GetIsEnemyAlive();  //checks if enemy is still alive

        }
    }

}
