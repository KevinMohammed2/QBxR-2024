using UnityEngine;

public class Crossing : MonoBehaviour
{
    public float speed = 5f;
    public float curveDist = 8f;
    private Vector3 startPos;
    private bool isCurving = true;
    private Vector3 curveDirection;

    void Start()
    {
        startPos = transform.position;
        curveDirection = (Quaternion.Euler(0, 45, 0) * Vector3.right).normalized; 
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
}