using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    SoundManager soundManager;
    GameObject effects;

    [SerializeField] GameObject enemyParent;
    [SerializeField] ParticleSystem bulletFX;
    [SerializeField] ParticleSystem deathFX;
    [SerializeField] ParticleSystem damageBaseFX;
    [SerializeField] int health = 5;

    public bool isEnemyAlive;

    private void Awake()
    {
        isEnemyAlive = true;
    }

    // Use this for initialization
    void Start ()
    {
        effects = GameObject.Find("Effects");
        soundManager = FindObjectOfType<SoundManager>() as SoundManager;
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
        bulletFXGO.transform.SetParent(effects.transform, true);
        Destroy(bulletFXGO.gameObject, 1f);
    }

    void DeathExplosion(Vector3 enemyPos)
    {
        soundManager.PlayEnemyDeathSound();
        ParticleSystem deathFXGO = Instantiate(deathFX, enemyPos, Quaternion.identity);
        deathFXGO.Play();
        deathFXGO.transform.SetParent(effects.transform, true);
        Destroy(deathFXGO, 1f);
    }

    public void DamageBase(Vector3 enemyPos)
    {
        soundManager.PlayEnemyBaseDamageSound();

        ParticleSystem damageBaseFXGO = Instantiate(damageBaseFX, enemyPos, Quaternion.identity, effects.transform);
        damageBaseFXGO.Play();
        Destroy(damageBaseFXGO, 1f);
        Destroy(gameObject);
    }

    private void Death()
    {
        if(health <= 0)
        {
            isEnemyAlive = false;
            DeathExplosion(new Vector3 (transform.position.x, transform.position.y + 5, transform.position.z));
            Destroy(enemyParent);
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
