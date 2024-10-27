using UnityEngine;
using System.Runtime.InteropServices;

public class ScoreManager : MonoBehaviour
{
  [DllImport("__Internal")]
  private static extern void SaveScoreToLocalStorage(int score);

  public static ScoreManager Instance { get; private set; } // Singleton instance
  private int score = 0; // Tracks the number of completed passes

  private void Awake()
  {
    // Ensure only one instance exists
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject); // Keep this object between scenes
    }
    else
    {
      Destroy(gameObject); // Destroy duplicate instances
    }
  }

  // Method to add score for a completed pass
  public void AddScore()
  {
    score += 1;
  }

  // Get the current score
  public int GetScore()
  {
    return score;
  }

  public int SaveScore()
  {
    int finalScore = GetScore();

#if UNITY_WEBGL && !UNITY_EDITOR
        SaveScoreToLocalStorage(finalScore);  // Call the JS function to save the score
#endif

    return finalScore;
  }

  // Reset the score (optional, for replaying)
  public void ResetScore()
  {
    score = 0;
  }
}
