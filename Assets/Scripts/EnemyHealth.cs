using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] ParticleSystem bulletFX;
    [SerializeField] ParticleSystem deathFX;
    [SerializeField] Light deathLightFX;

    [SerializeField] int health = 5;

    float effectTimer;
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
        boxCollider.GetComponent<BoxCollider>().center = new Vector3(0, 3.4f, 0);
        boxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update ()
    {
        effectTimer += Time.deltaTime;
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
        ParticleSystem deathFXGO = Instantiate(deathFX, transform.position, Quaternion.identity);
        deathFXGO.Play();
        effectTimer = 0;
        deathLightFX.enabled = true;
        Destroy(deathFXGO, 1f);
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
