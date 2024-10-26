using UnityEngine;

public class ScoreManager : MonoBehaviour
{
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

  // Reset the score (optional, for replaying)
  public void ResetScore()
  {
    score = 0;
  }
}
