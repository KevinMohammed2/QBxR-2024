using UnityEngine;
using UnityEngine.InputSystem; // Required for Input System

public class MoveAtAngle : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    public float yardDist = 10f; // Distance in yards
    public float moveAngle = 45f; // Angle in degrees for movement direction
    private Vector3 startPos;
    private float timeElapsed = 0f;
    public float stopTime = 4f; // Maximum time allowed for movement
    public InputActionProperty ButtonInput; // Assign the input action for 'A' button in the inspector
    private bool movementStarted = false; // Flag to track if movement has started

    void Start()
    {
        startPos = transform.position;

        // Make sure the A button input action is enabled
        // ButtonInput.action.Enable();
    }

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
            timeElapsed += Time.deltaTime;
            float distCovered = Vector3.Distance(startPos, transform.position);
            
            if (distCovered < yardDist)
            {
                // Calculate the direction based on the given angle
                Vector3 moveDirection = Quaternion.Euler(0, moveAngle, 0) * Vector3.forward;
                transform.Translate(moveDirection * speed * Time.deltaTime);
            }
        }
    }
}
