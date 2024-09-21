using UnityEngine;

public class BallThrown : MonoBehaviour
{
    public BallThrown ball;
    // First need to change the logic of storing the routes into a class PlayerMovement

    // Then change this so the PlayerMovement is the thing that stops

    // Update is called once per frame
    void OnCollisionEnter(Collision collsion)
    {
        if (collsion.collider.tag == "BlackTeam")
        {
            // Stop the players movement
            // Pass Complete 
        }
        else if (collsion.collider.tag == "GoldTeam")
        {
            // Stop the players movement
            // Pass Incomplete
        }
        else if (collsion.collider.tag == "FootballField") // Or this can be an else statement 
        {
            // Stop the players movement
            // Pass Incomplete 
        }
    }
}
