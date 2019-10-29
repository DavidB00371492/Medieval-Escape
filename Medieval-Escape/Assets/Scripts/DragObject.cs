using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    //Temporary code used for dragging objects
    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 6.33f);
        Vector3 objectPosition = cam.ScreenToWorldPoint(mousePosition);
        transform.position = objectPosition;
    }

    // Update is called once per frame 
    void Update()
    {
        
    }
}
