using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool caught = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    //public void CompleteLevel()
    //{
    //    completeLevelUI.SetActive(true);
    //}

    public void EndGame()
    {
        if (caught == false)
        {
            caught = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
