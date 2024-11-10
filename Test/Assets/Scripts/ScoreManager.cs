using UnityEngine;
using System.Runtime.InteropServices;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
  [DllImport("__Internal")]
  private static extern void SendScores(float difficulty1Average, float difficulty2Average, float difficulty3Average);

  public static ScoreManager Instance { get; private set; } // Singleton instance

  [System.Serializable]
  public class ScoreListWrapper
  {
    // Use an array instead of a List
    public int difficulty1;
    public float difficulty1Score;

    public int difficulty2;
    public float difficulty2Score;

    public int difficulty3;
    public float difficulty3Score;

    // Constructor that converts a List to an array
    public ScoreListWrapper()
    {
      difficulty1 = 0;
      difficulty2 = 0;
      difficulty3 = 0;

      difficulty1Score = 0;
      difficulty2Score = 0;
      difficulty3Score = 0;
    }

    public void reset()
    {
      difficulty1 = 0;
      difficulty2 = 0;
      difficulty3 = 0;

      difficulty1Score = 0;
      difficulty2Score = 0;
      difficulty3Score = 0;
    }
  }

  // List to hold scores for each play
  ScoreListWrapper scores = new ScoreListWrapper();

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
    if (playDifficulty == 1)
    {
      scores.difficulty1++;
      scores.difficulty1Score += scoreValue;
    }
    else if (playDifficulty == 2)
    {
      scores.difficulty2++;
      scores.difficulty2Score += scoreValue;
    }
    else if (playDifficulty == 3)
    {
      scores.difficulty3++;
      scores.difficulty3Score += scoreValue;
    }
  }

  // Reset scores (optional, for replaying)
  public void ResetScores()
  {
    scores.reset();
  }

  public void SaveScore()
  {
    float difficulty1Average = scores.difficulty1Score / scores.difficulty1;
    float difficulty2Average = scores.difficulty2Score / scores.difficulty2;
    float difficulty3Average = scores.difficulty3Score / scores.difficulty3;

#if UNITY_WEBGL && !UNITY_EDITOR
    SendScores(difficulty1Average, difficulty2Average, difficulty3Average);
#endif
  }
}
