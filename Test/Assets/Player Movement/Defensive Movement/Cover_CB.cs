using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem; // Required for Input System
using UnityEngine;

public class Cover_CB : MonoBehaviour
{
  public float speed = 5f;            // Speed for moving backward
  public float backwardAngle = 0f;   // Angle for moving backward
  private Vector3 startPos;           // Starting position of the player
  private float timeElapsed = 0f;     // Time tracker
  public float stopTime = 4f;         // Time to stop the movement, can be adjusted as needed
  public InputActionProperty ButtonInput; // Assign the input action for 'A' button in the inspector
  private bool movementStarted = false; // Flag to track if movement has started

  void Start()
  {
    startPos = transform.position;

    // Make sure the A button input action is enabled
    ButtonInput.action.Enable();
  }

  // Update is called once per frame
  void Update()
  {
    // Check if the 'A' button is pressed to start the movement
    if (!movementStarted && FootballHoldManager.Instance.IsFootballHeld() && ButtonInput.action.WasPressedThisFrame())
    {
      movementStarted = true;
    }

    if (movementStarted)
    {
      timeElapsed += Time.deltaTime; // Increment the elapsed time

      if (timeElapsed < stopTime)
      {
        // Create a direction vector for the backward movement based on the specified angle
        Vector3 backwardDirection = Quaternion.Euler(0, backwardAngle, 0) * Vector3.back;

        // Move in the specified backward direction
        transform.Translate(backwardDirection * speed * Time.deltaTime, Space.World);
      }
    }
  }
}
