using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class SceneResetter : MonoBehaviour
{
    // This method can be called to reset the scene
    public void ResetScene()
    {
        // Get the current scene and reload it
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
