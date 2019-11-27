using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    float distance = 10;

    //When the player holds the mouse on the object and drags, the object's position follows the mouse position
    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objectPosition;
    }
}
