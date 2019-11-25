using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float movement;
    private bool facingRight = true;
    private Rigidbody2D rb;
    [Range(0, 20)]
    public float jumpForce;


    void Start()
    {
        //Finds and allocates the player's rigidbody2d
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }

        //If the player collides with an object tagged "objective" they are taken to the next level
        if (collision.gameObject.name.Equals("Objective"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        //If the player collides with a moving platform, the player object becomes a child of the platform causing it to move with the platform
        if(collision.transform.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }

    //If the player stops colliding with a moving platform, the player's parent property is set to null
    private void OnCollisionExit2D(Collision2D collision)
    {
             if(collision.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }  
    }



    void Update()
    {
        //If the A key is pressed and the player is facing right, the player is flipped left
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (facingRight)
                FlipCharacter();
        }

        //If the D key is pressed and the player isn't already facing right, the player is flipped righ
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!facingRight)
                FlipCharacter();
        }

        //If the space key is pressed, the player jumps
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }


    }

    //Flips the character on the horizontal axis when executed
    void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    //Restarts the level when executed
    void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    void FixedUpdate()
    {
        //Handles player movement
        movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }
}
