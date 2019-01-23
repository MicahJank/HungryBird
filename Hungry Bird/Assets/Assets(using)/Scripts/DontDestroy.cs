using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private string _name;
    private List<string> _objectNames = new List<string>();

    private void Awake()
    {
        FindDuplicatedObject();
        CheckListSize();
    }

    private void FindDuplicatedObject()
    {
        _name = this.gameObject.name;
        GameObject[] objects = GameObject.FindGameObjectsWithTag(this.tag);
        foreach (GameObject obj in objects)
        {
            if (obj.name == this.name)
            {
                _objectNames.Add(obj.name); // Duplicated objs get moved into the list
            }
        }
    }

    private void CheckListSize()
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

