using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseHealth : MonoBehaviour
{
    SoundManager soundManager;

    public int baseCurrentHealth = 100;


    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>() as SoundManager;
    }

    private void OnTriggerEnter(Collider other)
    {   
        print("Your base is taking damage!" + "Remaing Health: " + baseCurrentHealth);
        baseCurrentHealth -= 10;
    }
}
