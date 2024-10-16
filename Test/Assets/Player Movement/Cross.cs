using GLTFast.Schema;
using UnityEngine;

public class Cross : MonoBehaviour
{
    public float speed = 5f;            // Speed of movement
    public float yardDist = 5f;         // Distance to change direction
    public float initialAngle = 45f;    // Initial slant angle
    public float newAngle = 0f;         // New angle after the first slant
    public bool directionChange = false; // Flag to indicate if the direction has changed
    private Vector3 startPos;           // Starting position of the object
    private float timeElapsed = 0f;     // Elapsed time
    public float stopTime = 4f;         // Time to stop movement

    void Start()
    {
        startPos = transform.position; // Record the starting position
    }

    void Update()
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
                    directionChange = true; // Change direction after reaching yardDist
                }
            }
            else
            {
                // Move in the new direction after the initial slant
                Vector3 newDirection = Quaternion.Euler(0, newAngle, 0) * Vector3.forward;
                transform.Translate(newDirection * speed * Time.deltaTime, Space.World);
            }
        }
    }
}
