using UnityEngine;
using UnityEngine.InputSystem; // Required for Input System

public class Flat : MonoBehaviour, IRoute
{
  public float speed = 5f;
  public float firstDist = 2f; // Distance for the first segment
  public float secondDist = 5f; // Distance for the second segment
  public float thirdDist = 1f; // Distance for the third segment
  private Vector3 startPos;
  private float timeElapsed = 0f;
  public float stopTime = 6f; // Allow extra time for the entire route
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

    // // Run movement only if 'A' button has been pressed
    if (movementStarted)
    {
      timeElapsed += Time.deltaTime;
      float distCover = Vector3.Distance(startPos, transform.position);

      switch (phase)
      {
        case 0: // Initial angle to the left for 2 yards
          if (distCover < firstDist)
          {
            Vector3 leftAngle = new Vector3(-2.5f, 0, 1).normalized; // Slight angle left
            transform.Translate(leftAngle * speed * Time.deltaTime);
          }
          else
          {
            phase++;
            startPos = transform.position; // Update startPos for next phase
          }
          break;

        case 1: // More angled upward for 5 yards
          if (distCover < secondDist)
          {
            Vector3 upwardAngle = new Vector3(-5.5f, 0, 1).normalized; // Slightly more angled upward
            transform.Translate(upwardAngle * speed * Time.deltaTime);
          }
          else
          {
            phase++;
            startPos = transform.position; // Update startPos for next phase
          }
          break;

        case 2: // Slight cut down left for 1 yard
          if (distCover < thirdDist)
          {
            Vector3 downLeftAngle = new Vector3(-1, 0, -0.2f).normalized; // Slight cut down to the left
            transform.Translate(downLeftAngle * speed * Time.deltaTime);
          }
          else
          {
            phase++;
          }
          break;
      }
    }
  }
}
