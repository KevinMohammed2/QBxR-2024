using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FootballHoldManager : MonoBehaviour
{
  public static FootballHoldManager Instance { get; private set; }

  private bool isFootballHeld = false;  // Tracks if the football is held

  private void Awake()
  {
    // Ensure only one instance of FootballHoldManager exists
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);  // Persist across scenes
    }
    else
    {
      Destroy(gameObject);  // Destroy duplicate instances
    }
  }

  // Method to set hold status, called by the football itself
  public void SetFootballHeldStatus(bool status)
  {
    isFootballHeld = status;
  }

  // Method to check if football is held
  public bool IsFootballHeld()
  {
    return isFootballHeld;
  }
}
