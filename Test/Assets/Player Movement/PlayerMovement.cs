using GLTFast.Schema;
using UnityEngine;

/* 
 * Create a start button that would start the routes 
 * Buttons/dropdown to select the routes per WR on the Canvas example given
 * 
 */
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float yardDist = 5f;
    public float slantAngle = 45f;
    public bool directionChange = false;
    public Vector3 startPos;
    public float timeElasped = 0f;
    public float stopTime = 4f;

    void Start()
    {
        startPos = transform.position;
    }
}

public class Slant2 : PlayerMovement
{
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

public class Out : PlayerMovement
{
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
        }
        else
        {
            Vector3 cutDirection = Quaternion.Euler(0, slantAngle, 0) * Vector3.forward;
            transform.Translate(cutDirection * speed * Time.deltaTime);
        }
    }
}