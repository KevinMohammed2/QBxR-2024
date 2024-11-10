using UnityEngine;
using UnityEngine.UI;

public class ExitVR : MonoBehaviour
{
  private void Start()
  {
    // Add a listener to the button to call the ExitGame method when clicked
    if (ScoreManager.Instance != null)
    {
      ScoreManager.Instance.SaveScore();
    }

  }
}