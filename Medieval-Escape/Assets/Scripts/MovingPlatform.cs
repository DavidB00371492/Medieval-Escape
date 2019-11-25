using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 startPosition;

    private Vector3 endPosition;

    private Vector3 nextPosition;

    public float speed;

    public Transform platform;

    public Transform endPoint;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the start position to the platform's original location
        startPosition = platform.localPosition;
        //Sets the end position to the location of he end point transform
        endPosition = endPoint.localPosition;
        //The next position is automatically set to the end position as the platform will always begin at the start position
        nextPosition = endPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //Moves the platform from it's current position to the next position at the given speed
    private void Move()
    {
        platform.localPosition = Vector3.MoveTowards(platform.localPosition, nextPosition, speed * Time.deltaTime);

        if(Vector3.Distance(platform.localPosition, nextPosition) <= 0.1)
        {
            ChangeDirction();
        }
    }

    private void ChangeDirction()
    {
        if(nextPosition != startPosition)
        {
            nextPosition = startPosition;
        }
        else
        {
            nextPosition = endPosition; 
        }
    }
}
