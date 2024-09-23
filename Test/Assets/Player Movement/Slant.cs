using GLTFast.Schema;
using UnityEngine;

public class Slant : MonoBehaviour
{
  public float speed = 5f;
  public float yardDist = 5f;
  public float slantAngle = 45f;
  public bool directionChange = false;
  private Vector3 startPos;
  private float timeElasped = 0f;
  public float stopTime = 4f;

  void Start()
  {
    startPos = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    timeElasped += Time.deltaTime;
    if (timeElasped < stopTime)
    {
      if (!directionChange)
      {
        float distCover = Vector3.Distance(startPos, transform.position);
        if (distCover < yardDist)
        {
          transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
          directionChange = true;
        }
      }
      else
      {
        Vector3 slantDirection = Quaternion.Euler(0, slantAngle, 0) * Vector3.forward;
        transform.Translate(slantDirection * speed * Time.deltaTime);
      }
    }

  }
}
