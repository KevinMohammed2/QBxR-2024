using UnityEngine;
using UnityEngine.SceneManagement;

public class Landing : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
