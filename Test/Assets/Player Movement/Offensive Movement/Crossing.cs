using UnityEngine;

public class Crossing : MonoBehaviour, IRoute
{
  public float speed = 5f;
  public float firstAngleDist = 5f;  // Distance for the first angled movement
  public float secondAngleDist = 2f; // Distance for the second angled movement
  private Vector3 startPos;
  private int routePhase = 0;        // 0: first angle, 1: second angle, 2: horizontal
  private Vector3 firstDirection;
  private Vector3 secondDirection;
  private Vector3 horizontalDirection;

  public float playerScore = 1f;    // Property to get the player score
  float IRoute.playerScore => playerScore;

  void Start()
  {
    startPos = transform.position;

    // Define the directions for each phase
    firstDirection = (Quaternion.Euler(0, 30, 0) * Vector3.forward).normalized; // Slight angle up
    secondDirection = (Quaternion.Euler(0, 45, 0) * Vector3.forward).normalized; // Slight angle cut
    horizontalDirection = Vector3.right; // Horizontal to the right
  }

  void Update()
  {
    float distCovered = Vector3.Distance(startPos, transform.position);

    if (routePhase == 0)
    {
      // Move up at a slight angle for a few yards
      if (distCovered < firstAngleDist)
      {
        transform.Translate(firstDirection * speed * Time.deltaTime, Space.World);
      }
      else
      {
        // Transition to the second angled cut
        routePhase = 1;
        startPos = transform.position; // Reset startPos for the next phase
      }
    }
    else if (routePhase == 1)
    {
      // Cut at a slight angle for a yard or two
      if (distCovered < secondAngleDist)
      {
        transform.Translate(secondDirection * speed * Time.deltaTime, Space.World);
      }
      else
      {
        // Transition to the horizontal movement
        routePhase = 2;
        startPos = transform.position; // Reset startPos for the next phase
      }
    }
    else if (routePhase == 2)
    {
      // Move horizontally to the right
      transform.Translate(horizontalDirection * speed * Time.deltaTime, Space.World);
    }
  }
}
