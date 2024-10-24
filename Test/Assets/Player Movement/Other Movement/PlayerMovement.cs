/* 
 * Create a start button that would start the routes 
 * Buttons/dropdown to select the routes per WR on the Canvas example given
 * 
 */
using GLTFast.Schema;
using UnityEngine;
using UnityEngine.InputSystem; // Required for Input System

public class PlayerMovement : MonoBehaviour
{
  public float speed = 5f;
  public float newSpeed = 5f;
  public float yardDist = 5f;
  public float slantAngle = 45f;
  public Vector3 startPos;
  public float timeElapsed = 0f;
  public float stopTime = 4f;
  public float startPressure = 4f;
  public bool newSpeedFlag = false;
  public bool isDLine = false;
  public InputActionProperty ButtonInput; // Assign the input action for 'A' button in the inspector

  // Flag to track if movement has started
  private bool movementStarted = false;
  private bool directionChange = false;

  public void Start()
  {
    startPos = transform.position;

    // Make sure the A button input action is enabled
    ButtonInput.action.Enable();
  }

  public void Update()
  {
    // Check if the 'A' button is pressed to start the movement
    if (!movementStarted && ButtonInput.action.WasPressedThisFrame())
    {
      movementStarted = true;
    }

    // Run movement only if 'A' button has been pressed
    if (movementStarted)
    {
      timeElapsed += Time.deltaTime;

      if (isDLine)
      {
        if (timeElapsed > startPressure)
        {
          MoveForward();
        }
      }
      else
      {
        if (timeElapsed < stopTime)
        {
          if (!directionChange)
          {
            MoveForward();
          }
          else
          {
            MoveSlant();
          }
        }
      }
    }
  }

  // Common Forward Movement Function
  protected void MoveForward()
  {
    float userSpeed = speed;
    if (newSpeedFlag && directionChange)
    {
      userSpeed = newSpeed;
    }

    float distCover = Vector3.Distance(startPos, transform.position);
    if (distCover < yardDist)
    {
      transform.Translate(Vector3.forward * userSpeed * Time.deltaTime);
    }
    else
    {
      directionChange = true;
    }
  }

  // Slant Movement
  protected void MoveSlant()
  {
    float userSpeed = speed;
    if (newSpeedFlag && directionChange)
    {
      userSpeed = newSpeed;
    }
    Vector3 slantDirection = Quaternion.Euler(0, slantAngle, 0) * Vector3.forward;
    transform.Translate(slantDirection * userSpeed * Time.deltaTime);
  }
}