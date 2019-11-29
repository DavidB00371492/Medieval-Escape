using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate2 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If there's a collision with the player or an anvil, the object named '002' is destroyed
        if (collision.CompareTag("Player") || collision.CompareTag("Anvil"))
        {
            Destroy(GameObject.Find("002"));
        }
    }
}
