using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLine : MonoBehaviour
{

    public float speed = 2f;          // Speed during the slant cut
    public float newSpeed = 5f;       // Speed after the slant, during the "go" route
    public float yardDist = 10f;      // Distance to cut before going straight (set to 10 units as example)
    public float slantAngle = 40f;    // Angle of the initial cut
    private bool cut = true;          // Whether the player is in the cut phase
    private Vector3 startPos;         // Starting position of the player
    private float timeElapsed = 0f;   // Time tracker
    public float stopTime = 4f;
    public float startPressure = 4f;       // Time to stop the route, can be adjusted as needed

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Start in the same position
        // After 3.5-4 seconds, each d line man moves up and presses
        timeElapsed += Time.deltaTime;
        if (timeElapsed < stopTime)
        {
            if (timeElapsed > startPressure)
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
        }
        // no more pressure after 
    }
}
