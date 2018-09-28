using System;
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
    [SerializeField] int towerRange = 20;  //towers shooting range

    Transform enemyDistance;
    int nearestEnemy;

    float timer;
    float fireRate = .5f;

    private void Start()
    {
        enemy = GameObject.Find("Enemy");  //instance of object reference
        enemyHealth = enemy.GetComponent<EnemyHealth>();  //gets script from object that was referenced
        towerBullets = GetComponentInChildren<ParticleSystem>();  //gets particlesystem
    }

    // Update is called once per frame
    void Update ()
    {
        timer += Time.deltaTime;

        if(targetEnemy)
        {
            if (timer >= fireRate)
            {
                timer = 0;
                ShootNearestEnemy(true);
            }
            //else
            //{
            //    ShootNearestEnemy(false);
            //}
        }
	}

    //used to check if enemy is in range
    private void ShootNearestEnemy(bool isShooting)
    {
        //variable must be float in order for .magnitude to change the vectors to a floating number.
        //round to nearest int
        nearestEnemy = (int)Mathf.RoundToInt((targetEnemy.transform.position - transform.position).magnitude);

        if (nearestEnemy <= towerRange)
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
