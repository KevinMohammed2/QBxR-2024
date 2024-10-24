using GLTFast.Schema;
using UnityEngine;
using UnityEngine.InputSystem; // Required for Input System

public class In : MonoBehaviour
{
    public float preCutSpeed = 3f;  // Speed before the cut
    public float postCutSpeed = 7f; // Speed after the cut
    public float yardDist = 7f;     // Distance before making a cut
    public float inAngle = 90f;     // Sharp 90-degree cut for an In route
    public bool directionChange = false;
    private Vector3 startPos;
    private float timeElapsed = 0f;
    public float stopTime = 5f;
    public InputActionProperty ButtonInput; // Assign the input action for 'A' button in the inspector
    private bool movementStarted = false; // Flag to track if movement has started

    void Start()
    {
        startPos = transform.position;

        // Make sure the A button input action is enabled
        ButtonInput.action.Enable();
    }

    // Update is called once per frame
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
            timeElapsed += Time.deltaTime;
            if (timeElapsed < stopTime)
            {
                if (!directionChange)
                {
                    float distCovered = Vector3.Distance(startPos, transform.position);
                    if (distCovered < yardDist)
                    {
                        // Move forward with pre-cut speed
                        transform.Translate(Vector3.forward * preCutSpeed * Time.deltaTime);
                    }
                    else
                    {
                        directionChange = true;
                    }
                }
                else
                {
                    // Make a sharp 90-degree cut inside
                    Vector3 inDirection = Quaternion.Euler(0, -inAngle, 0) * Vector3.forward;
                    // Move in the new direction with post-cut speed
                    transform.Translate(inDirection * postCutSpeed * Time.deltaTime);   
                }
            }
        }
    }
}
