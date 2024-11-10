using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class FootballSpin : MonoBehaviour
{
  public float spinForce = 500f;
  public float timeToThrow = 5f;
  private float timeElapsed = 0f;
  private Rigidbody rb;
  private bool isThrown = false;
  private bool passCompleted = false;
  private bool playStarted = false;

  private XRGrabVelocityTracked grabInteractable;
  private int playDifficulty = 0;
  public InputActionProperty ButtonInput;

  private Transform targetParent;
  private Vector3 relativePosition;

  public NextScene nextScene;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
    grabInteractable = GetComponent<XRGrabVelocityTracked>();
  }

  private void FixedUpdate()
  {
    // Apply spin only if the football has been thrown
    if (isThrown)
    {
      rb.AddTorque(transform.right * spinForce * Time.fixedDeltaTime, ForceMode.Force);
    }

    if (!playStarted && FootballHoldManager.Instance.IsFootballHeld() && ButtonInput.action.WasPressedThisFrame())
    {
      timeElapsed = 0f;
      playStarted = true;
    }

    if (!isThrown && FootballHoldManager.Instance.IsFootballHeld())
    {
      timeElapsed += Time.fixedDeltaTime;

      if (playStarted && timeElapsed >= timeToThrow)
      {
        DisableInteraction();

        if (ScoreManager.Instance != null)
        {
          ScoreManager.Instance.AddScore(playDifficulty, 0);
        }

        if (nextScene != null)
        {
          nextScene.ShowResultPanel("You took too long!");
        }
      }
    }

    if (passCompleted && targetParent != null)
    {
      transform.position = targetParent.TransformPoint(relativePosition);
    }
  }

  // Called when the ball is released/thrown
  public void OnSelectExited(SelectExitEventArgs args)
  {
    isThrown = true;
    FootballHoldManager.Instance.SetFootballHeldStatus(false);
  }

  // Called when the ball is grabbed again
  public void OnSelectEntered(SelectEnterEventArgs args)
  {
    isThrown = false;
    FootballHoldManager.Instance.SetFootballHeldStatus(true);
  }

  // Called when the football hits the ground
  private void OnCollisionEnter(Collision collision)
  {
    if (!isThrown || passCompleted)
      return;

    if (!playStarted)
    {
      isThrown = false;
      return;
    }

    string sceneName = SceneManager.GetActiveScene().name;
    switch (sceneName)
    {
      case "PlayOne":
        playDifficulty = 3;
        break;
      case "PlayTwo":
        playDifficulty = 1;
        break;
      case "PlayThree":
        playDifficulty = 3;
        break;
      case "PlayFour":
        playDifficulty = 2;
        break;
      case "PlayFive":
        playDifficulty = 3;
        break;
      case "PlaySix":
        playDifficulty = 2;
        break;
      case "PlaySeven":
        playDifficulty = 1;
        break;
      case "PlayEight":
        playDifficulty = 2;
        break;
      case "PlayNine":
        playDifficulty = 3;
        break;
      case "PlayTen":
        playDifficulty = 2;
        break;
    }

    if (
        collision.gameObject.CompareTag("FootballField")
        || collision.gameObject.CompareTag("GoldTeam")
    )
    {
      isThrown = false;

      if (ScoreManager.Instance != null)
      {
        ScoreManager.Instance.AddScore(playDifficulty, 0);
      }

      if (nextScene != null)
      {
        nextScene.ShowResultPanel("Incomplete Pass!");
      }
    }
    else if (collision.gameObject.CompareTag("BlackTeam"))
    {
      isThrown = false;

      IRoute route = collision.gameObject.GetComponent<IRoute>();
      float playerScore = 0f;
      if (route != null)
      {
        playerScore = route.playerScore;
      }
      else
      {
        Debug.LogWarning("No IRoute component found on collided BlackTeam object.");
      }

      passCompleted = true;
      DisableInteraction();

      targetParent = collision.transform;
      relativePosition = targetParent.InverseTransformPoint(transform.position);

      rb.isKinematic = true;
      if (ScoreManager.Instance != null)
      {
        ScoreManager.Instance.AddScore(playDifficulty, playerScore);
      }

      if (nextScene != null)
      {
        nextScene.ShowResultPanel("Pass Completed!");
      }
    }
  }

  // Disable the grab interactable and collider to prevent further interaction
  private void DisableInteraction()
  {
    if (grabInteractable != null)
    {
      grabInteractable.enabled = false; // Disable the grab interactable component
    }

    Collider ballCollider = GetComponent<Collider>(); // Get the football's collider
    if (ballCollider != null)
    {
      ballCollider.enabled = false; // Disable the collider (optional)
    }
  }
}
