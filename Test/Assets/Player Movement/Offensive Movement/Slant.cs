using GLTFast.Schema;
using UnityEngine;
using UnityEngine.InputSystem; // Required for Input System

public class Slant : MonoBehaviour
{
  public float speed = 5f;
  public float yardDist = 5f;
  public float slantAngle = 45f;
  public bool directionChange = false;
  private Vector3 startPos;
  private float timeElasped = 0f;
  public float stopTime = 4f;
  public InputActionProperty ButtonInput; // Assign the input action for 'A' button in the inspector
  private bool movementStarted = false; // Flag to track if movement has started

  void Start()
  {
    startPos = transform.position;

    // Make sure the A button input action is enabled
    // ButtonInput.action.Enable();
  }

  // Update is called once per frame
  void Update()
  {
    // Check if the 'A' button is pressed to start the movement
    // if (!movementStarted && ButtonInput.action.WasPressedThisFrame())
    // {
    //     movementStarted = true;
    // }

    // // Run movement only if 'A' button has been pressed
    // if (movementStarted)
    {
      timeElasped += Time.deltaTime;
      if (timeElasped < stopTime)
      {
        if (!directionChange)
        {
          float distCover = Vector3.Distance(startPos, transform.position);
          if (distCover < yardDist)
          {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
          }
          else
          {
            directionChange = true;
          }
        }
        else
        {
          Vector3 slantDirection = Quaternion.Euler(0, slantAngle, 0) * Vector3.forward;
          transform.Translate(slantDirection * speed * Time.deltaTime);
        }
      }
    }
  }
}