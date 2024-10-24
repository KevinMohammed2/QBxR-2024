using GLTFast.Schema;
using UnityEngine;

public class Hitch : MonoBehaviour
{
    public float speed = 5f;
    public float yardDist = 5f; // Shorter distance before hitch stop
    public bool stopped = false;
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
            if (!stopped)
            {
                float distCover = Vector3.Distance(startPos, transform.position);
                if (distCover < yardDist)
                {
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                else
                {
                    stopped = true;
                }
            }
        }
    }
}