using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class FootballSpin : MonoBehaviour
{
  public float spinForce = 500f;  // Adjust this to control how fast the ball spins
  private Rigidbody rb;
  private bool isThrown = false;  // Tracks if the ball has been thrown
  public TextMeshProUGUI passResultText;

  private bool passCompleted = false; // Track if the pass is completed

  private XRGrabVelocityTracked grabInteractable; // Reference to the XR Grab Interactable

  private Transform targetParent; // Store the BlackTeam's transform
  private Vector3 relativePosition; // Store the football's relative position to the BlackTeam

  private void Start()
  {
    rb = GetComponent<Rigidbody>();  // Get the Rigidbody attached to the football
    grabInteractable = GetComponent<XRGrabVelocityTracked>();  // Get the XR Grab Interactable component
  }

  private void FixedUpdate()
  {
    // Apply spin only if the football has been thrown
    if (isThrown)
    {
      rb.AddTorque(transform.right * spinForce * Time.fixedDeltaTime, ForceMode.Force);
    }

    // If pass completed, keep football at the correct relative position to the BlackTeam
    if (passCompleted && targetParent != null)
    {
      // Keep football in the relative position
      transform.position = targetParent.TransformPoint(relativePosition);
    }
  }

  // Called when the ball is released/thrown
  public void OnSelectExited(SelectExitEventArgs args)
  {
    isThrown = true;  // Start spinning when the ball is released
  }

  // Called when the ball is grabbed again
  public void OnSelectEntered(SelectEnterEventArgs args)
  {
    isThrown = false;  // Stop spinning when grabbed again
  }

  // Called when the football hits the ground
  private void OnCollisionEnter(Collision collision)
  {
    // If pass is already completed, ignore further collisions
    if (passCompleted) return;

    // Check if the football collided with the ground
    // Incomplete Pass
    if (collision.gameObject.CompareTag("FootballField") || collision.gameObject.CompareTag("GoldTeam"))
    {
      isThrown = false;  // Stop spinning when the football hits the ground
      passResultText.text = "Incomplete Pass!";
      Debug.Log("Incomplete Pass!");
    }
    // Complete Pass
    else if (collision.gameObject.CompareTag("BlackTeam"))
    {
      isThrown = false;  // Stop spinning when the football hits the ground
      passResultText.text = "Pass Completed!";
      Debug.Log("Pass Completed!");

      passCompleted = true;  // Mark pass as completed

      // Disable interaction with the football
      DisableInteraction();

      // Set the target parent (BlackTeam)
      targetParent = collision.transform;

      // Calculate the relative position of the football to the BlackTeam at the moment of collision
      relativePosition = targetParent.InverseTransformPoint(transform.position);

      // Optionally, disable physics to stop the football from falling
      rb.isKinematic = true;
    }
  }

  // Disable the grab interactable and collider to prevent further interaction
  private void DisableInteraction()
  {
    if (grabInteractable != null)
    {
      grabInteractable.enabled = false;  // Disable the grab interactable component
    }

    Collider ballCollider = GetComponent<Collider>();  // Get the football's collider
    if (ballCollider != null)
    {
      ballCollider.enabled = false;  // Disable the collider (optional)
    }
  }
}
