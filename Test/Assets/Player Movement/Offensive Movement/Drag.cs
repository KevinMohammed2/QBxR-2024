using UnityEngine;

public class Drag : MonoBehaviour
{
    public float speed = 5f;
    public float diagonalDist = 2f; // Distance for the diagonal movement
    public float straightDist = 8f; // Distance for the straight right movement after the diagonal
    private Vector3 startPos;
    private bool diagonalComplete = false;
    private Vector3 diagonalDirection;
    private Vector3 straightDirection;

    void Start()
    {
        startPos = transform.position;
        diagonalDirection = (Quaternion.Euler(0, 45, 0) * Vector3.right).normalized; // 45-degree diagonal to the right
        straightDirection = Vector3.right; // Straight to the right
    }

    void Update()
    {
        float distCovered = Vector3.Distance(startPos, transform.position);

        if (!diagonalComplete)
        {
            if (distCovered < diagonalDist)
            {
                // Move diagonally to the right for 2 yards
                transform.Translate(diagonalDirection * speed * Time.deltaTime);
            }
            else
            {
                // Diagonal movement is done, move to straight right movement
                diagonalComplete = true;
                startPos = transform.position; // Reset startPos for straight distance tracking
            }
        }
        else
        {
            float straightDistCovered = Vector3.Distance(startPos, transform.position);
            if (straightDistCovered < straightDist)
            {
                // Move straight to the right
                transform.Translate(straightDirection * speed * Time.deltaTime);
            }
        }
    }
}
