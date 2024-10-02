using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class Landing : MonoBehaviour
{
  // This method can be called to start the game
  public void StartGame(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
  }
}
