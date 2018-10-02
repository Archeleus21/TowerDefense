using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public AudioClip enemySpawnSFX;
    public AudioClip towerShootingSFX;
    public AudioClip enemyDeathSFX;
    public AudioClip enemyBaseDamageSFX;
    public AudioSource gameAudioSource;

	// Use this for initialization
	void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    public void PlayEnemySpawnSound()
    {
        gameAudioSource.PlayOneShot(enemySpawnSFX);
 
    }

    public void PlayTowerShootSound()
    {
        gameAudioSource.PlayOneShot(towerShootingSFX);
    }

    public void PlayEnemyDeathSound()
    {
        gameAudioSource.PlayOneShot(enemyDeathSFX);
    }

    public void PlayEnemyBaseDamageSound()
    {
        gameAudioSource.PlayOneShot(enemyBaseDamageSFX);
    }
}
