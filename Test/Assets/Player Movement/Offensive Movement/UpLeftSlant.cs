using UnityEngine;
using UnityEngine.InputSystem; // Required for Input System

public class ModifiedRoute : MonoBehaviour, IRoute
{
  public float speed = 5f;
  public float yardDist = 5f; // Set yard distance to 5 for each segment
  public float slantAngle = 45f; // Slant angle at 45 degrees
  private Vector3 startPos;
  private float timeElapsed = 0f;
  public float stopTime = 4f;
  public InputActionProperty ButtonInput; // Assign the input action for 'A' button in the inspector
  private bool movementStarted = false; // Flag to track if movement has started
  private int phase = 0; // Track which phase of the movement we are in

  public float playerScore = 1f;    // Property to get the player score
  float IRoute.playerScore => playerScore;

  void Start()
  {
    startPos = transform.position;

    // Make sure the A button input action is enabled
    ButtonInput.action.Enable();
  }

  void Update()
  {
    // Check if the 'A' button is pressed to start the movement
    if (!movementStarted && FootballHoldManager.Instance.IsFootballHeld() && ButtonInput.action.WasPressedThisFrame())
    {
      movementStarted = true;
    }

    // Run movement only if 'A' button has been pressed
    if (movementStarted)
    {
      timeElapsed += Time.deltaTime;
      if (timeElapsed < stopTime)
      {
        float distCover = Vector3.Distance(startPos, transform.position);
        switch (phase)
        {
          case 0: // Move up 5 yards
            if (distCover < yardDist)
            {
              transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
              phase++;
              startPos = transform.position; // Update startPos for next phase
            }
            break;

          case 1: // Move left 5 yards
            if (distCover < yardDist)
            {
              transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
              phase++;
              startPos = transform.position; // Update startPos for next phase
            }
            break;

          case 2: // Slant upwards at a 45-degree angle
            Vector3 slantDirection = Quaternion.Euler(0, slantAngle, 0) * Vector3.forward;
            transform.Translate(slantDirection * speed * Time.deltaTime);
            break;
        }
      }
    }
  }
}
