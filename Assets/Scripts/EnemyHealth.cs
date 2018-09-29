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

    private void Awake()
    {
        isEnemyAlive = true;
    }

    // Use this for initialization
    void Start ()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.GetComponent<BoxCollider>().size = new Vector3(7, 7, 7);
        boxCollider.GetComponent<BoxCollider>().center = new Vector3(0, 6.5f, 0);
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
        BulletFX();
    }

    void BulletFX()
    {
        ParticleSystem bulletFXGO = Instantiate(bulletFX, transform.position, Quaternion.identity);
        bulletFXGO.Play();
        Destroy(bulletFXGO.gameObject, 1f);
    }

    void DeathExplosion(Vector3 enemyPos)
    {
        ParticleSystem deathFXGO = Instantiate(deathFX, enemyPos, Quaternion.identity);
        deathFXGO.Play();
        Destroy(deathFXGO, 1f);
    }

    private void Death()
    {
        if(health <= 0)
        {
            isEnemyAlive = false;
            DeathExplosion(new Vector3 (transform.position.x, transform.position.y + 5, transform.position.z));
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
