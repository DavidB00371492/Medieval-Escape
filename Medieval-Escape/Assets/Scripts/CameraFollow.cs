using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{ 
    private Transform player;
    public float xOffset;
    public float yOffset;
    private Vector3 targetPosition;

    void Start()
    {
        //finds the player transform by locating the object tagged "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        //Sets the target position to that of the player's x any y positions plus the offsets
        targetPosition = new Vector3(player.position.x + xOffset, player.position.y + yOffset, transform.position.z);
        //Sets the position of the camera to the target position
        transform.position = targetPosition;
    }
}
