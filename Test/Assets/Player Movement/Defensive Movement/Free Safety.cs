using UnityEngine;
using UnityEngine.InputSystem; // Required for Input System

public class ZoneCoverage : MonoBehaviour
{
  public float speed = 5f;           // Speed of movement
  public float coverageAngle = -45f; // Angle for coverage, negative to move left
  public float yardDist = 10f;       // Distance to cover before stopping or changing movement
  public float startDelay = 3f;      // Delay in seconds before movement starts
  private Vector3 startPos;          // Starting position of the free safety
  private bool coverageActive = false; // Flag to determine if coverage movement is active
  private float timeElapsed = 0f;    // Time elapsed since the start

  public InputActionProperty ButtonInput; // Assign the input action for 'A' button in the inspector
  private bool movementStarted = false; // Flag to track if movement has started

  void Start()
  {
    // Record the starting position of the free safety
    startPos = transform.position;

    // Make sure the A button input action is enabled
    ButtonInput.action.Enable();
  }

  void Update()
  {
    // Increment the elapsed time

    // Check if the 'A' button is pressed to start the movement
    if (!movementStarted && ButtonInput.action.WasPressedThisFrame())
    {
      movementStarted = true;
    }

    // Run movement only if 'A' button has been pressed
    if (movementStarted)
    {
      timeElapsed += Time.deltaTime;

      // Activate coverage movement after the start delay
      if (!coverageActive && timeElapsed >= startDelay)
      {
        coverageActive = true;
      }

      // Perform coverage movement if active
      if (coverageActive)
      {
        // Measure how far the player has moved from the start
        float distCovered = Vector3.Distance(startPos, transform.position);

        if (distCovered < yardDist)
        {
          // Move in the direction defined by the coverage angle
          Vector3 coverageDirection = Quaternion.Euler(0, coverageAngle, 0) * Vector3.forward;
          transform.Translate(coverageDirection * speed * Time.deltaTime, Space.World);
        }
        else
        {
          // Stop movement after covering the specified distance
          coverageActive = false;
        }
      }
    }
  }
}
