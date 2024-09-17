using UnityEngine;

public class OutRoute : MonoBehaviour
{
    public float speed = 5f;
    public float yardDist = 10f;
    public float slantAngle = 90f;
    public bool ninetyCut = false;
    private Vector3 startPos;
    private float timeElasped = 0f;
    public float stopTime = 4f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        timeElasped += Time.deltaTime;
        if (timeElasped < stopTime)
        {
            if (!ninetyCut)
            {
                float distCover = Vector3.Distance(startPos, transform.position);
                if (distCover < yardDist)
                {
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                else
                {
                    ninetyCut = true;
                }
            }
        }
        else
        {
            Vector3 cutDirection = Quaternion.Euler(0, slantAngle, 0) * Vector3.forward;
            transform.Translate(cutDirection * speed * Time.deltaTime);
        }
    }
}
