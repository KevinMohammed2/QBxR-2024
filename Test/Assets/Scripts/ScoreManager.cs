using UnityEngine;
using System.Runtime.InteropServices;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
  [DllImport("__Internal")]
  private static extern void SaveScoreToLocalStorage(List<PlayScore> scores);

  public static ScoreManager Instance { get; private set; } // Singleton instance

  [System.Serializable]
  public class PlayScore
  {
    public int playDifficulty;  // Difficulty of the play
    public float score;         // Score for the play

    public PlayScore(int difficulty, float scoreValue)
    {
      playDifficulty = difficulty;
      score = scoreValue;
    }
  }

  // List to hold scores for each play
  private List<PlayScore> scores = new List<PlayScore>();

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

  // Method to add a score for a completed play with difficulty
  public void AddScore(int playDifficulty, float scoreValue)
  {
    scores.Add(new PlayScore(playDifficulty, scoreValue));
  }

  // Get all scores
  public List<PlayScore> GetScores()
  {
    return scores;
  }

  // Reset scores (optional, for replaying)
  public void ResetScores()
  {
    scores.Clear();
  }

  public void SaveScore()
  {
    foreach (var playScore in scores)
    {
      Debug.Log("Final Scores: " + playScore.playDifficulty + " - " + playScore.score);
    }

#if UNITY_WEBGL && !UNITY_EDITOR
        SaveScoreToLocalStorage(scores);  // Call the JS function to save the score
#endif
  }
}
