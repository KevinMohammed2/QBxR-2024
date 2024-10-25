using UnityEngine;
using UnityEngine.InputSystem; // Required for Input System
public class OutRoute : MonoBehaviour
{
  public float speed = 5f;
  public float yardDist = 10f;
  public float slantAngle = 90f;
  public bool ninetyCut = false;
  private Vector3 startPos;
  private float timeElasped = 0f;
  public float stopTime = 4f;
  public InputActionProperty ButtonInput; // Assign the input action for 'A' button in the inspector
  private bool movementStarted = false; // Flag to track if movement has started

  void Start()
  {
    startPos = transform.position;

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
      timeElasped += Time.deltaTime;
      if (timeElasped < stopTime)
      {
        if (!ninetyCut)
        {
          float distCover = Vector3.Distance(startPos, transform.position);
          if (distCover < yardDist)
          {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
          }
          else
          {
            ninetyCut = true;
          }
        }
        else
        {
          Vector3 cutDirection = Quaternion.Euler(0, slantAngle, 0) * Vector3.forward;
          transform.Translate(cutDirection * speed * Time.deltaTime);
        }
      }
    }
  }
}
