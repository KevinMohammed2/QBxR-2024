using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewPlayArt : MonoBehaviour
{
  public GameObject imageObject;        // Reference to the Image GameObject
  public Button button;                 // Reference to the Button component
  public Text canvasText;    // Reference to the Text on the Parent Canvas
  public string newCanvasText = "Play Name"; // The text to display when the button is clicked
  public GameObject parentCanvas;       // Reference to the Parent Canvas GameObject

  private void Start()
  {
    // Ensure the image starts inactive
    imageObject.SetActive(false);

    // Add a listener to the button click event
    button.onClick.AddListener(OnButtonClick);
  }

  // Method to be called when the button is clicked
  private void OnButtonClick()
  {
    // Hide the button
    button.gameObject.SetActive(false);

    // Change the text on the parent canvas
    if (canvasText != null)
    {
      canvasText.text = newCanvasText;
    }

    // Show the image
    imageObject.SetActive(true);

    // Start a coroutine to disable the parent canvas after 10 seconds
    StartCoroutine(DisableCanvasAfterDelay(5f));
  }

  // Coroutine to disable the canvas after a delay
  private IEnumerator DisableCanvasAfterDelay(float delay)
  {
    // Wait for the specified amount of time (10 seconds)
    yield return new WaitForSeconds(delay);

    // Disable the entire parent canvas
    if (parentCanvas != null)
    {
      parentCanvas.SetActive(false);
    }
  }
}
