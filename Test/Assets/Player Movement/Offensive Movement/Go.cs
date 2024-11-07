using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem; // Required for Input System
using UnityEngine;

public class Go : MonoBehaviour, IRoute
{
  public float speed = 5f;
  public float yardDist = 5f;
  private Vector3 startPos;
  private float timeElasped = 0f;
  public float stopTime = 9f;

  private bool movementStarted = false; // Flag to track if movement has started
  public InputActionProperty ButtonInput; // Assign the input action for 'A' button in the inspector

  public float playerScore = 1f;    // Property to get the player score
  float IRoute.playerScore => playerScore;

  void Start()
  {
    startPos = transform.position;

    ButtonInput.action.Enable();
  }

  // Update is called once per frame
  void Update()
  {

    timeElasped += Time.deltaTime;

    if (!movementStarted && FootballHoldManager.Instance.IsFootballHeld() && ButtonInput.action.WasPressedThisFrame())
    {
      movementStarted = true;
    }

    // Run movement only if 'A' button has been pressed
    if (movementStarted)
    {
      if (timeElasped < stopTime)
      {
        float distCover = Vector3.Distance(startPos, transform.position);
        if (distCover < yardDist)
        {
          transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

      }
    }
  }
}
