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

    float yThrow, xThrow;

    [SerializeField] float pitchPositionFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;

    [SerializeField] float yawPositionFactor = 5f;
    [SerializeField] float controlYawFactor = 20f;

    [SerializeField] float controlRollFactor = -20f;



    // Update is called once per frame
    void Update()
    {
        MovementCheck();
        RotationCheck();
    }

    // The ORDER OF ROTATIONS MATTER and object should always rotate on the Y axis first
    private void RotationCheck() // TODO Smooth the transition from rotating to stop rotating for controler
    {
        float pitchByPosition = transform.localPosition.y * pitchPositionFactor;
        float pitchByControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchByPosition + pitchByControlThrow;

        float yawByPosition = transform.localPosition.x * yawPositionFactor;
        float yawByControlThrow = xThrow * controlYawFactor;
        float yaw = yawByPosition + yawByControlThrow;

        float roll = xThrow * controlRollFactor;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void MovementCheck()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float yOffset = yThrow * _ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        float xOffset = xThrow * _xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); // player will not go off screen

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
