using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWhereFiring : MonoBehaviour
{
    [SerializeField] private Raycast raycast; // the script that makes the raycast
    [SerializeField] private GameObject aim;
    [SerializeField] private PlayerMovement playerMovement;

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.isControlEnabled)
        {
            transform.LookAt(aim.transform);
        }
       
    }
}
