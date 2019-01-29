using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Only ok as long as this is the only script that loads scenes

public class PlayerCollisions : MonoBehaviour
{
    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 3f;

    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        BeginExplosion();
        Invoke("LoadCurrentScene", levelLoadDelay);

    }

    private void StartDeathSequence()
    {
        SendMessage("DisableControls");
       
    }

    private void BeginExplosion()
    {
        deathFX.SetActive(true);
    }

   private void LoadCurrentScene() // String Reference
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
} 
