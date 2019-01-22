using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Invoke("Load", 2f);
    }

    private void Load()
    {
        SceneManager.LoadScene(1);
    }
}
