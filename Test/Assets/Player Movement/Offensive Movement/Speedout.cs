using UnityEngine;

public class Speedout : MonoBehaviour
{
public float speed = 5f;
public float curveDist = 15f;
private Vector3 startPos;
private bool isCurving = true;
private Vector3 curveDirection;

  void Start()
  {
    startPos = transform.position;
    curveDirection = new Vector3(1f, 0.5f, 0).normalized;
  }

  void Update()
  {
        if (isCurving)
        {
            float distCovered = Vector3.Distance(startPos, transform.position);
            if (distCovered < curveDist)
            {
                transform.Translate(curveDirection * speed * Time.deltaTime);
            }
            else
            {
                isCurving = false;
            }
        }
    }

    private void ResetPosition()
    {
    transform.position = startPos;
    isCurving = true;
    }
}