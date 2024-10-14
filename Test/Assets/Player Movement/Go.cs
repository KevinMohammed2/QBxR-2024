using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go: MonoBehaviour
{
    public float speed = 5f;
    public float yardDist = 5f;
    private Vector3 startPos;
    private float timeElasped = 0f;
    public float stopTime = 9f;
    
    void Start()
    {
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        timeElasped += Time.deltaTime;
        if (timeElasped < stopTime){
            float distCover = Vector3.Distance(startPos, transform.position);
            if (distCover < yardDist)
            {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        
        }
}
}
