using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem; // Required for Input System
using UnityEngine;

public class SlightGo : MonoBehaviour
{
    public float speed = 2f;          // Speed during the slant cut
    public float newSpeed = 5f;       // Speed after the slant, during the "go" route
    public float yardDist = 10f;      // Distance to cut before going straight (set to 10 units as example)
    public float slantAngle = 40f;    // Angle of the initial cut
    public float maxDistance = 30f;   // Maximum distance before stopping the movement
    private bool cut = true;          // Whether the player is in the cut phase
    private Vector3 startPos;         // Starting position of the player
    private float totalDistance = 0f; // Total distance covered
    
    private bool movementStarted = false; // Flag to track if movement has started
    public InputActionProperty ButtonInput; // Assign the input action for 'A' button in the inspector

    void Start()
    {
        startPos = transform.position; // Record the player's start position

        // Make sure the A button input action is enabled
        ButtonInput.action.Enable();
    }

    void Update()
    {
        // Check if the 'A' button is pressed to start the movement
        if (!movementStarted && ButtonInput.action.WasPressedThisFrame())
        {
            movementStarted = true;
        }

        // Run movement only if 'A' button has been pressed
        if (movementStarted)
        {
            // Measure how far the player has moved from the start
            float distCovered = Vector3.Distance(startPos, transform.position);
            totalDistance = distCovered;

            // Stop moving if the total distance covered exceeds the maxDistance
            if (totalDistance >= maxDistance)
            {
                return; // Stop further execution to halt movement
            }

            if (cut)
            {
                // Create a direction vector for the slant based on the slant angle
                Vector3 cutDirection = Quaternion.Euler(0, slantAngle, 0) * Vector3.forward;

                // If the player has not yet covered the slant distance, continue slanting
                if (distCovered < yardDist)
                {
                    transform.Translate(cutDirection * speed * Time.deltaTime, Space.World);
                }
                else
                {
                    // Transition to the "go" route after covering the slant distance
                    cut = false;
                }
            }
            else
            {
                // Move straight forward after the slant cut
                transform.Translate(Vector3.forward * newSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
