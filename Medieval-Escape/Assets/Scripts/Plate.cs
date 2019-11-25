using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If there's a collision with the player, the object named '001' is destroyed
        if(collision.CompareTag("Player"))
        {
            Destroy(GameObject.Find("001"));
        }
    }
}
