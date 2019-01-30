using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDuplicates : MonoBehaviour
{
    private string _name;
    private List<string> _objectNames = new List<string>(); // To store the objects

    private void Awake()
    {
        FindDuplicates();
        DestroyDuplicateObjects();
    }

    private void FindDuplicates()
    {
        _name = this.gameObject.name; 
        GameObject[] objects = GameObject.FindGameObjectsWithTag(this.tag); // Finds ALL objects with the tag
        foreach (GameObject obj in objects) // Cycles through EACH object
        {
            if (obj.name == this.name) // Finds the DUPLICATED objects
            {
                _objectNames.Add(obj.name); // Duplicated objects get moved into the list
            }
        }
    }

    private void DestroyDuplicateObjects()
    {
        if (_objectNames.Count > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

