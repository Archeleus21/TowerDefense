using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text baseHealthText;
    [SerializeField] Text enemySpawnText;

    PlayerBaseHealth baseHealth;
    EnemySpawner enemySpawnCounter;

    private void Start()
    {
        baseHealth = FindObjectOfType<PlayerBaseHealth>();
        enemySpawnCounter = FindObjectOfType<EnemySpawner>();
    }

    private void Update()
    {
        baseHealthText.text = baseHealth.baseCurrentHealth.ToString();
        enemySpawnText.text = enemySpawnCounter.enemyCount.ToString();
        
    }

}
