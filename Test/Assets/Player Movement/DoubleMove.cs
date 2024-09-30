using GLTFast.Schema;
using UnityEngine;

public class DoubleMove : MonoBehaviour
{
  public float speed = 5f;
  public float yardDist = 5f;
  public float slantAngle = 45f;
  public bool directionChange = false;
  private Vector3 startPos;
  private float timeElasped = 0f;
  public float stopTime = 4f;
  private bool firstSlant = false;
  private bool secondSlant = false;
  private Vector3 firstSlantPos;
  private Vector3 secondSlantPos;

  void Start()
  {
    startPos = transform.position;
  }

// move forward till first slant 
// slant 
// move forward till second slant 
// slant 
// move forward till end 

  // Update is called once per frame
  void Update()
  {
  
    if (!firstSlant)
    {
      if (Vector3.Distance(startPos, transform.position) < yardDist)
      {
        moveForward();
      }
      else
      {
        firstSlantMovement();
      }
    }
    else if (firstSlant && !secondSlant)
    {
      if (Vector3.Distance(firstSlantPos, transform.position) < yardDist)
      {
        moveForward();
      }
      else
      {
        secondSlantMovement();
      }
    }
    else if (secondSlant)
    {
      moveForward();
    }
  }

  void moveForward()
  {
    transform.Translate(Vector3.forward * speed * Time.deltaTime);
  }

  void firstSlantMovement()
  {
    firstSlantPos = transform.position;
    Vector3 slantDirection = Quaternion.Euler(0, -slantAngle, 0) * Vector3.forward; // turn direction to the left 
    transform.Translate(slantDirection * speed * Time.deltaTime); // move forward on the second slant
    firstSlant = true;
  }

  void secondSlantMovement()
  {
    firstSlantPos = transform.position;
    Vector3 slantDirection = Quaternion.Euler(0, slantAngle, 0) * Vector3.forward; // turn direction to the left 
    transform.Translate(slantDirection * speed * Time.deltaTime); // move forward on the second slant
    secondSlant = true;
  }
}