using UnityEngine;
using UnityEngine.InputSystem; // Required for Input System

public class CutUp : MonoBehaviour
{
    public float speed = 5f;
    public float initialDist = 3f; // Distance for the initial movement at -45 degrees
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
                case 0: // Move at a -45 degree angle
                    if (distCovered < initialDist)
                    {
                        Vector3 angleDirection = Quaternion.Euler(0, -55f, 0) * Vector3.forward;
                        transform.Translate(angleDirection * speed * Time.deltaTime);
                    }
                    else
                    {
                        phase++;
                        phaseStartPos = transform.position; // Update start position for the next phase
                    }
                    break;

                case 1: // Cut upwards for 3 yards
                    if (distCovered < 3f)
                    {
                        transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    }
                    else
                    {
                        phase++; // End of the movement sequence
                    }
                    break;
            }
        }
    }
}
