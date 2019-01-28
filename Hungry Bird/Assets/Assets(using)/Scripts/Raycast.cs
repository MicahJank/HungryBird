using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private float distance = 60f; // the distance the player will look when shooting
    public Vector3 end;
    public Vector3 hitPoint;
    [SerializeField] private GameObject aim;

    // Update is called once per frame
    void Update()
    { 
        Vector3 crossHairScreenPos = Camera.main.WorldToScreenPoint(this.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(crossHairScreenPos.x, crossHairScreenPos.y));     
        end = ray.GetPoint(distance);
        aim.transform.position = end;

        Debug.DrawRay(ray.origin, ray.direction * distance, Color.yellow); //TODO remove line of code when done testing
        

    }
}
