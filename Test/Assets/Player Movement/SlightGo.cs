using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlightGo : MonoBehaviour
{
  public float speed = 2f;          // Speed during the slant cut
  public float newSpeed = 5f;       // Speed after the slant, during the "go" route
  public float yardDist = 10f;      // Distance to cut before going straight (set to 10 units as example)
  public float slantAngle = 40f;    // Angle of the initial cut
  private bool cut = true;          // Whether the player is in the cut phase
  private Vector3 startPos;         // Starting position of the player
  private float timeElapsed = 0f;   // Time tracker
  public float stopTime = 4f;       // Time to stop the route, can be adjusted as needed

  void Start()
  {
    startPos = transform.position; // Record the player's start position
  }

  void Update()
  {
    timeElapsed += Time.deltaTime; // Increment the elapsed time

    if (timeElapsed < stopTime)
    {
      if (cut)
      {
        // Create a direction vector for the slant based on the slant angle
        Vector3 cutDirection = Quaternion.Euler(0, slantAngle, 0) * Vector3.forward;

        // Measure how far the player has moved from the start
        float distCovered = Vector3.Distance(startPos, transform.position);

        // If the player has not yet covered the slant distance, continue slanting
        if (distCovered < yardDist)
        {
          transform.Translate(cutDirection * speed * Time.deltaTime, Space.World);
        }
        else
        {
          // Transition to the "go" route after covering the slant distance
          cut = false;
        }
      }
      else
      {
        // Move straight forward after the slant cut
        transform.Translate(Vector3.forward * newSpeed * Time.deltaTime, Space.World);
      }
    }
  }
}
