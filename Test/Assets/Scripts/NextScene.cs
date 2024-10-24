using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
  public GameObject resultPanel; // UI panel to display the result
  public Text resultText;        // Text element to show "Complete" or "Incomplete"
  public Button nextPlayButton;  // Button to proceed to the next play

  private bool playEnded = false; // Flag to check if play is over

  void Start()
  {
    // Ensure the result panel and button are not active at the start
    resultPanel.SetActive(false);
    nextPlayButton.gameObject.SetActive(false);

    // Add a listener to the button to call LoadNextLevel when clicked
    nextPlayButton.onClick.AddListener(LoadNextLevel);
  }

  public void ShowResultPanel(string result)
  {
    // Display the result
    resultPanel.SetActive(true);
    resultText.text = result;
    nextPlayButton.gameObject.SetActive(true); // Show the button to proceed
  }
  public void LoadNextLevel()
  {
    // Load the next scene in the build order
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
}
