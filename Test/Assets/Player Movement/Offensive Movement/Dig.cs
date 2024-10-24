using GLTFast.Schema;
using UnityEngine;

public class Dig : MonoBehaviour
{
    public float speed = 5f;
    public float yardDist = 12f; // Longer distance before making the dig cut
    public float digAngle = 90f; // Sharp 90-degree cut for the Dig route
    public bool directionChange = false;
    private Vector3 startPos;
    private float timeElasped = 0f;
    public float stopTime = 7f; // Allow for a longer duration

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
                // Make a sharp 90-degree cut inside after deep route
                Vector3 digDirection = Quaternion.Euler(0, -digAngle, 0) * Vector3.forward;
                transform.Translate(digDirection * speed * Time.deltaTime);   
            }
        }
    }
}