using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("FX prefab on enemy")] [SerializeField] GameObject deathFX;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particles Collided with Enemy: " + gameObject.name);
        Instantiate(deathFX, gameObject.transform.position, Quaternion.identity);
        DestroyEnemy();
        
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
