using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Falling_Object : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

void OnTriggerEnter2D (Collider2D collision)
    {
        //If there's a collision with the player object, isKinematic is disabled causing the object to fall
        if(collision.gameObject.name.Equals ("Player"))
        {
            rb.isKinematic = false;
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        //If there's a collision with the player object, the scene is reset
        if (collision.gameObject.name.Equals("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

       if(collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }

    }
}
