using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public GameObject dialogPanel; // Reference to the game panel
  public Text dialogText; // Reference to the text element in the game panel
  public float dialogDistance = 2f; // Distance from the camera where the game appears

  private Camera mainCamera;

  private void Start()
  {
    mainCamera = Camera.main; // Reference to the main camera
  }

  // Method to show the game with a specific message
  public void ShowDialog(string message)
  {
    dialogText.text = message; // Set the message in the dialog text
    dialogPanel.SetActive(true); // Show the dialog panel

    // Position the dialog in front of the camera
    PositionDialog();
  }

  // Method to hide the dialog
  public void HideDialog()
  {
    dialogPanel.SetActive(false); // Hide the dialog panel
  }

  // Position the dialog in front of the camera
  private void PositionDialog()
  {
    if (mainCamera != null)
    {
      // Calculate the position in front of the camera
      Vector3 dialogPosition = mainCamera.transform.position + mainCamera.transform.forward * dialogDistance;
      dialogPanel.transform.position = dialogPosition; // Set the dialog position
      dialogPanel.transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward); // Face the camera
    }
  }
}
