using UnityEngine;
using UnityEngine.InputSystem; // Required for Input System

public class CornerbackCoverage : MonoBehaviour
{
    public float speed = 5f;               // Speed of movement
    public float angleFirstDirection = -45f; // Angle for the first direction
    public float angleSecondDirection = 45f;  // Angle for the second direction
    public float distanceFirstPhase = 3f;  // Distance to cover in the first phase (3 yards)
    public float distanceSecondPhase = 5f;  // Distance to cover in the second phase (5 yards)
    public float startDelay = 3f;          // Delay in seconds before movement starts
    private Vector3 startPos;              // Starting position of the free safety
    private bool coverageActive = false;   // Flag to determine if coverage movement is active
    private float timeElapsed = 0f;        // Time elapsed since the start
    private int movementPhase = 0;         // Current movement phase (0 for first direction, 1 for second direction)
    private float phaseDistanceCovered = 0f; // Distance covered in the current phase
    private bool movementComplete = false;  // Flag to track if movement is complete

    public InputActionProperty ButtonInput; // Assign the input action for 'A' button in the inspector
    private bool movementStarted = false;   // Flag to track if movement has started

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

            // Perform coverage movement if active and not complete
            if (coverageActive && !movementComplete)
            {
                // Measure how far the player has moved in the current phase
                phaseDistanceCovered = Vector3.Distance(startPos, transform.position);

                // Determine the movement angle and distance based on the current phase
                float currentDistance = movementPhase == 0 ? distanceFirstPhase : distanceSecondPhase;
                float coverageAngle = movementPhase == 0 ? angleFirstDirection : angleSecondDirection;

                if (phaseDistanceCovered < currentDistance)
                {
                    // Move in the direction defined by the current coverage angle
                    Vector3 coverageDirection = Quaternion.Euler(0, coverageAngle, 0) * Vector3.forward;
                    transform.Translate(coverageDirection * speed * Time.deltaTime, Space.World);
                }
                else
                {
                    // Stop movement after covering the specified distance
                    movementPhase++; // Move to the next phase
                    startPos = transform.position; // Update start position for the next phase
                    phaseDistanceCovered = 0f; // Reset distance covered for the next movement phase

                    // If the second phase is completed, mark the movement as complete
                    if (movementPhase > 1)
                    {
                        movementComplete = true; // Mark movement as complete
                        coverageActive = false;   // Deactivate coverage movement
                    }
                }
            }
        }
    }
}
