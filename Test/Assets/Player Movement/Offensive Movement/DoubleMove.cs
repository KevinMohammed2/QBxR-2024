using GLTFast.Schema;
using UnityEngine;
using UnityEngine.InputSystem; // Required for Input System

public class DoubleMove : MonoBehaviour
{
    public float speed = 5f;
    public float firstDist = 3f; // Distance for the first slant
    public float secondDist = 5f; // Distance for the upward movement
    public float thirdDist = 3f; // Distance for the second slant
    public float slantAngle = 45f; // Angle for slant movements
    private Vector3 startPos;
    private int phase = 0; // Tracks the current phase of movement
    private Vector3 phaseStartPos; // Start position for each phase
    private bool movementStarted = false;
    public InputActionProperty ButtonInput; // Assign the input action for 'A' button in the inspector


    void Start()
    {
        startPos = transform.position;
        phaseStartPos = startPos;

        ButtonInput.action.Enable();
    }

    void Update()
    {

      if (!movementStarted && ButtonInput.action.WasPressedThisFrame())
      {
          movementStarted = true;
      }

      if (movementStarted)
      {

        float distCovered = Vector3.Distance(phaseStartPos, transform.position);
        
        switch (phase)
        {
            case 0: // Slant right 45 degrees for 3 yards
              if (distCovered < firstDist)
              {
                  Vector3 slantDirection = Quaternion.Euler(0, slantAngle, 0) * Vector3.forward;
                  transform.Translate(slantDirection * speed * Time.deltaTime);
              }
              else
              {
                  phase++;
                  phaseStartPos = transform.position; // Update start position for the next phase
              }
              break;

          case 1: // Move upwards for 5 yards
              if (distCovered < secondDist)
              {
                  transform.Translate(Vector3.forward * speed * Time.deltaTime);
              }
              else
              {
                  phase++;
                  phaseStartPos = transform.position; // Update start position for the next phase
              }
              break;

          case 2: // Slant right again at 45 degrees for 3 yards
              if (distCovered < thirdDist)
              {
                  Vector3 slantDirection = Quaternion.Euler(0, slantAngle, 0) * Vector3.forward;
                  transform.Translate(slantDirection * speed * Time.deltaTime);
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
