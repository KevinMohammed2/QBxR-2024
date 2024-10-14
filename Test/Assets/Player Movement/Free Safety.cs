using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeSafety : MonoBehaviour
{
  public float speed = 5f;            // Speed for moving backward
  public float backwardAngle = 30f;   // Angle for moving backward
  private Vector3 startPos;           // Starting position of the player
  private float timeElapsed = 0f;     // Time tracker
  public float stopTime = 4f;         // Time to stop the movement, can be adjusted as needed

  void Start()
  {
    startPos = transform.position; // Record the player's start position
  }

  void Update()
  {
    timeElapsed += Time.deltaTime; // Increment the elapsed time

    if (timeElapsed < stopTime)
    {
      // Create a direction vector for the backward movement based on the specified angle
      Vector3 backwardDirection = Quaternion.Euler(0, backwardAngle, 0) * Vector3.back;

      // Move in the specified backward direction
      transform.Translate(backwardDirection * speed * Time.deltaTime, Space.World);
    }
  }
}
