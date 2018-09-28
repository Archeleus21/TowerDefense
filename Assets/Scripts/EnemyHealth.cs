using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] ParticleSystem bulletFX;
    [SerializeField] ParticleSystem deathFX;

    [SerializeField] int health = 5;

    public bool isEnemyAlive;

	// Use this for initialization
	void Start ()
    {
        bulletFX = GetComponentInChildren<ParticleSystem>();
        deathFX = GetComponentInChildren<ParticleSystem>();

        AddNonTriggerBoxCollider();
        isEnemyAlive = true;
	}

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.GetComponent<BoxCollider>().size = new Vector3(7, 7, 7);
        boxCollider.GetComponent<BoxCollider>().center = new Vector3(0, 3.4f, 0);
        boxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update ()
    {
        Death();
		
	}

    private void OnParticleCollision(GameObject other)
    {
        health--;
        bulletFX.Play();
    }

    void DeathExplosion(Vector3 enemyPos)
    {
        Instantiate(deathFX, transform.position, Quaternion.identity); //fix explosion

    }

    private void Death()
    {
        if(health <= 0)
        {
            isEnemyAlive = false;
            DeathExplosion(transform.position);
            Destroy(gameObject);
        }
        else
        {
            isEnemyAlive = true;
        }
    }

    public bool GetIsEnemyAlive()
    {
        return isEnemyAlive;
    }
}
