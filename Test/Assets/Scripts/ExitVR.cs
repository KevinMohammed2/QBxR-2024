using UnityEngine;
using UnityEngine.UI;

public class ExitVR : MonoBehaviour
{
  public Button exitButton; // Reference to the button that will exit the game
  public Text scoreText; // Reference to the score text

  private void Start()
  {
    // Add a listener to the button to call the ExitGame method when clicked
    if (ScoreManager.Instance != null)
    {
      int finalScore = ScoreManager.Instance.SaveScore();
      scoreText.text = $"Score: {finalScore} / 5";
    }

    exitButton.onClick.AddListener(ExitGame);
  }

  private void ExitGame()
  {
    // Quit the application
    Debug.Log("Exiting game...");
    Application.Quit();

    // Note: In the Unity Editor, Application.Quit() won't work. 
    // Use UnityEditor.EditorApplication.isPlaying = false; to stop play mode.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
  }
}