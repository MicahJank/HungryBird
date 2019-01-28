using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] float speed = 4f;
    float xAxis;
    float yAxis;

    float yRange = 2f;
    float xRange = 3.5f;


    // Update is called once per frame
    void Update()
    {
        if (playerMovement.isControlEnabled)
        {
            MoveCrossHair();
        }
    }

    private void MoveCrossHair()
    {
        xAxis = Input.GetAxis("HorizontalRightJS"); //TODO make crossplatform
        yAxis = Input.GetAxis("VerticalRightJS");

        Vector2 crossHairInitialPos = this.transform.localPosition;

        // move the reticle in whichever direction the axis is turned
        // clamp the movement so that it only goes so far
        float yOffset = yAxis * speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        float xOffset = xAxis * speed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
