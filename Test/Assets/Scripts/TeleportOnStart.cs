using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class TeleportOnStart : MonoBehaviour
{
  public Transform teleportTarget;            // Target position for teleportation (only X and Z will be used)
  public InputActionProperty ButtonInput;  // Assign the input action for 'A' button in the inspector
  public DynamicMoveProvider moveProvider;   // Reference to the locomotion system

  private bool hasTeleported = false;         // Flag to prevent multiple teleports

  void Start()
  {
    // Make sure the A button input action is enabled
    if (moveProvider != null)
    {
      moveProvider.enabled = true;  // Disables all locomotion-related movement
    }
    ButtonInput.action.Enable();
  }

  void Update()
  {
    if (!hasTeleported)
    {
      // Check if the primary button on the controller is pressed
      if (FootballHoldManager.Instance.IsFootballHeld() && ButtonInput.action.WasPressedThisFrame())
      {
        TeleportAndDisable();
      }
    }
  }

  private void TeleportAndDisable()
  {
    // Teleport the player to the target's X and Z, keeping their current Y
    if (teleportTarget != null)
    {
      Vector3 currentPosition = transform.position;
      Vector3 newPosition = new Vector3(teleportTarget.position.x, currentPosition.y, teleportTarget.position.z);
      transform.position = newPosition;

      hasTeleported = true;
    }
    else
    {
      Debug.LogWarning("Teleport target is not set.");
    }

    // Disable locomotion movement
    if (moveProvider != null)
    {
      moveProvider.enabled = false;  // Disables all locomotion-related movement
    }
  }
}
