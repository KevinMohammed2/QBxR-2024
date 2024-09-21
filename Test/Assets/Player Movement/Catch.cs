using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Slant movement;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindAnyObjectByType<GameManager>().EndGame();

        }
    }
}
