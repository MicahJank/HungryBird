using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
   [Tooltip("Time in seconds")] [SerializeField] private float time = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, time);
    }


}
