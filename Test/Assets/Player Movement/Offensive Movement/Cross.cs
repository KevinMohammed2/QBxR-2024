using GLTFast.Schema;
using UnityEngine;
using UnityEngine.InputSystem; // Required for Input System

public class Cross : MonoBehaviour, IRoute
{
  public float speed = 5f;              // Speed of movement
  public float yardDist = 5f;           // Distance to change direction (5 yards)
  public float initialAngle = 45f;      // Initial slant angle
  public float increasedAngle = 60f;    // Increased slant angle after covering 5 yards
  private bool directionChange = false; // Flag to indicate if the direction has changed
  private Vector3 startPos;             // Starting position of the object
  private float timeElapsed = 0f;       // Elapsed time
  public float stopTime = 4f;           // Time to stop movement



  public InputActionProperty ButtonInput; // Assign the input action for 'A' button in the inspector
  private bool movementStarted = false; // Flag to track if movement has started

  public float playerScore = 1f;    // Property to get the player score
  float IRoute.playerScore => playerScore;

  void Start()
  {
    startPos = transform.position; // Record the starting position

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
        float distCovered = Vector3.Distance(startPos, transform.position);

        if (!directionChange)
        {
          // Move in the initial slant direction
          Vector3 initialDirection = Quaternion.Euler(0, initialAngle, 0) * Vector3.forward;
          transform.Translate(initialDirection * speed * Time.deltaTime, Space.World);

          // Check if the distance covered is greater than or equal to yardDist
          if (distCovered >= yardDist)
          {
            directionChange = true; // Change direction after reaching 5 yards
          }
        }
        else
        {
          // Move in the increased slant direction after reaching 5 yards
          Vector3 increasedSlantDirection = Quaternion.Euler(0, increasedAngle, 0) * Vector3.forward;
          transform.Translate(increasedSlantDirection * speed * Time.deltaTime, Space.World);
        }
      }
    }
  }
}