using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    public float health = 1;
    private bool movingRight = true;
    public Transform groundDetection;

    //Removes health from the enemy when ran
    public void TakeDamage()
    {
        health -= 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the enemy collides with an anvil, they take damage
        if(collision.gameObject.tag == "Anvil")
        {
            Destroy(collision.collider.gameObject);
            TakeDamage();
        }
    }


    // Update is called once per frame
    void Update()
    {
       //If the enemies health reaches zero, they are destroyed
       if(health <= 0)
        {
            Destroy(gameObject);
        }

       //Moves the player's transform right at the given speed by default
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //Projects a raycast from the enemy plus the given distance downwards for detecting ground
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        //If there is no collision with the ground and the enemy is moving right, the enemy is flipped otherwise the enemy is flipped in the opposite direction
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
