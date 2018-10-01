using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    EnemyHealth enemyHealth;
    public Waypoint baseWaypoint;

    [SerializeField] Transform partToPivot;  //used to rotate top
    [SerializeField] Transform firePoint;  //firing position
    [SerializeField] ParticleSystem towerBullets; //used to store bullet particle
    [SerializeField] int towerRange = 20;  //towers shooting range

    Transform targetEnemy;  //used to look at the enemy
    Transform nearestEnemy;

    int enemyDistanceFromTower;

    float timer;
    float fireRate = .5f;

    private void Start()
    {
        enemyHealth = FindObjectOfType<EnemyHealth>();
        towerBullets = GetComponentInChildren<ParticleSystem>();  //gets particlesystem
    }

    // Update is called once per frame
    void Update ()
    {
        timer += Time.deltaTime;
        SetNewTargetNearestEnemy();

        if(targetEnemy)
        {
            if (fireRate <= timer)
            {
                timer = 0;
                ShootNearestEnemy(true);
            }
        }
        else
        {
            ShootNearestEnemy(false);
        }
    }

    //switches targets from current to next when one is closer than the other
    private void SetNewTargetNearestEnemy()
    {
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();  //using EnemyHealth to ensure object is an enemy

        if(enemies.Length == 0) {return; }

        nearestEnemy = enemies[0].transform;

        foreach(EnemyHealth enemy in enemies)
        {
            nearestEnemy = GetClosestEnemy(nearestEnemy, enemy.transform);
        }

        targetEnemy = nearestEnemy;
    }

    //finds closest enemy between multiple targets
    private Transform GetClosestEnemy(Transform enemyTargetA, Transform enemyTargetB)
    {

        int distanceToTargetA = (int)Mathf.RoundToInt((enemyTargetA.position - transform.position).magnitude);
        int distanceToTargetB = (int)Mathf.RoundToInt((enemyTargetB.position - transform.position).magnitude);

        if (distanceToTargetA < distanceToTargetB)
        {
            return enemyTargetA;
        }

        return enemyTargetB;
    }

    //used to check if enemy is in range
    private void ShootNearestEnemy(bool isShooting)
    {
        //variable must be float in order for .magnitude to change the vectors to a floating number.
        //round to nearest int
        if (enemyHealth.isEnemyAlive)
        {
            enemyDistanceFromTower = (int)Mathf.RoundToInt((targetEnemy.transform.position - transform.position).magnitude);
        }

        if (enemyDistanceFromTower <= towerRange)
        {
            partToPivot.LookAt(targetEnemy);  //used to track the enemy
            towerBullets.Play();  //shoot
        }
        else
        {
            towerBullets.Stop(); //stop shooting
        }
    }

    //visual range of tower
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, towerRange);
    }
}
