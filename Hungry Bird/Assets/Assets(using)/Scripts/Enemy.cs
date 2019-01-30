using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("FX prefab on enemy")] [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    

    private void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(1.5f, 1.5f, 3.8f);
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particles Collided with Enemy: " + gameObject.name);
        GameObject fx = Instantiate(deathFX, gameObject.transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        DestroyEnemy();
        
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
