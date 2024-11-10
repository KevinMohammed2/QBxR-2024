using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management
using UnityEngine.InputSystem; // Required for input system

public class SceneResetter : MonoBehaviour
{
  public GameObject resetCanvas;
  public InputActionProperty ButtonInput;
  // This method can be called to reset the scene
  void Start()
  {
    resetCanvas.SetActive(true);
  }

  void Update()
  {
    if (FootballHoldManager.Instance.IsFootballHeld() && ButtonInput.action.WasPressedThisFrame())
    {
      resetCanvas.SetActive(false);
    }
  }

  public void ResetScene()
  {
    // Get the current scene and reload it
    Scene currentScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(currentScene.name);
  }
}
