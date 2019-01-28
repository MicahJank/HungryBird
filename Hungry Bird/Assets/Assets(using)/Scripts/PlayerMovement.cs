using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; // import unity standard assets to use this

public class PlayerMovement : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float controlSpeed = 4f;
    [Tooltip("In m")] [SerializeField] float xRange = 1.7f;
    [Tooltip("In m")] [SerializeField] float yRangeMin = -1.2f;
    [Tooltip("In m")] [SerializeField] float yRangeMax = 0.7f;

    [Header("Screen-Position Factors")]
    [SerializeField] float pitchPositionFactor = -5f;
    [SerializeField] float yawPositionFactor = 5f;

    [Header("Control-Throw Factors")]
    [SerializeField] float controlYawFactor = 20f;
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] float controlPitchFactor = -20f;

    float yThrow, xThrow;

   public bool isControlEnabled = true;


    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            MovementCheck();
            RotationCheck();
        }
     
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
        xThrow = Input.GetAxis("Horizontal"); //TODO make crossplatform
        yThrow = Input.GetAxis("Vertical");

        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, yRangeMin, yRangeMax);

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); // player will not go off screen

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    public void DisableControls() // called by string reference
    {
        Debug.Log("Disable player controls");
        isControlEnabled = false;
    }
}
