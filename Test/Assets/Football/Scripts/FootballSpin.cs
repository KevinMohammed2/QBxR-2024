using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class FootballSpin : MonoBehaviour
{
  public float spinForce = 500f;  // Adjust this to control how fast the ball spins
  private Rigidbody rb;
  private bool isThrown = false;  // Tracks if the ball has been thrown
  public TextMeshProUGUI passResultText;
  //private GameManager gameManager;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();  // Get the Rigidbody attached to the football
    //gameManager = FindObjectOfType<GameManager>();  // Find the GameManager object in the scene
  }

  private void FixedUpdate()
  {
    // Apply spin only if the football has been thrown
    if (isThrown)
    {
      rb.AddTorque(transform.right * spinForce * Time.fixedDeltaTime, ForceMode.Force);
    }
  }

  // Called when the ball is released/thrown
  public void OnSelectExited(SelectExitEventArgs args)
  {
    isThrown = true;  // Start spinning when the ball is released
  }

  // Called when the ball is grabbed again
  public void OnSelectEntered(SelectEnterEventArgs args)
  {
    isThrown = false;  // Stop spinning when grabbed again
  }

  // Called when the football hits the ground
  private void OnCollisionEnter(Collision collision)
  {
    // Check if the football collided with the ground
    // Incomplete Pass
    if (collision.gameObject.CompareTag("FootballField") || collision.gameObject.CompareTag("GoldTeam"))
    {
      isThrown = false;  // Stop spinning when the football hits the ground
      passResultText.text = "Incomplete Pass!";
      Debug.Log("Incomplete Pass!");
      //gameManager.ShowDialog("Incomplete Pass!");
    }
    // Complete Pass
    else if (collision.gameObject.CompareTag("BlackTeam"))
    {
      isThrown = false;  // Stop spinning when the football hits the ground
      passResultText.text = "Pass Completed!";
      Debug.Log("Pass Completed!");
      //gameManager.ShowDialog("Pass Completed!");
    }
  }
}
