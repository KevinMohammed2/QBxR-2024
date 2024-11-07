using GLTFast.Schema;
using UnityEngine;
using UnityEngine.InputSystem; // Required for Input System


public class WheelLeft : MonoBehaviour, IRoute
{
  public float speed = 5f;
  public float radius = 5f;  // Radius of the semicircle
  public float arcDuration = 2f;  // Time to complete the semicircle
  private Vector3 startPos;
  private float timeElapsed = 0f;
  public float stopTime = 4f;
  private float angle = 0f;  // Current angle in the semicircle
  private Vector3 lastPosition;
  public InputActionProperty ButtonInput; // Assign the input action for 'A' button in the inspector
  private bool movementStarted = false; // Flag to track if movement has started

  public float playerScore = 1f;    // Property to get the player score
  float IRoute.playerScore => playerScore;

  void Start()
  {
    // Initialize startPos to the original position where the object is placed
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
        if (timeElapsed <= arcDuration)
        {
          // Start the wheel route (semicircular movement) after the straight run
          float arcProgress = timeElapsed / arcDuration;

          // Calculate the angle for the semicircle from 0 to 180 degrees
          angle = Mathf.Lerp(0, -180, arcProgress);

          // Convert the angle to radians since Unity works with radians
          float radianAngle = Mathf.Deg2Rad * angle;

          // Calculate the new position in the semicircle
          float z = -radius * Mathf.Sin(radianAngle);  // Move downwards first, then curve upwards
          float x = -radius * Mathf.Cos(radianAngle);   // Horizontal curve

          // Set the new position relative to where the straight movement stopped
          Vector3 newPosition = startPos + Vector3.left * (speed * arcDuration / 2) + new Vector3(x, 0, z);

          // Update the player's position
          transform.position = newPosition;
          lastPosition = newPosition;
        }
        else
        {
          transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
      }
    }
  }
}