using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; // import unity standard assets to use this

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float _xSpeed = 4f;
    [Tooltip("In ms^-1")] [SerializeField] float _ySpeed = 4f;
    [Tooltip("In m")] [SerializeField] float xRange = 2f;
    [Tooltip("In m")] [SerializeField] float yRange = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementCheck();
        RotationCheck();
    }

    // The ORDER OF ROTATIONS MATTER and object should always rotate on the Y axis first
    private void RotationCheck()
    {
        // Rotate the player on the y axis
        transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
    }

    private void MovementCheck()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float yOffset = yThrow * _ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        float xOffset = xThrow * _xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); // player will not go off screen

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
