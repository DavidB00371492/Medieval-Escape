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

    [SerializeField]
    private LayerMask groundLayer;

    void Start()
    {
        //Finds and allocates the player's rigidbody2d
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player collides with an object tagged 'Damage', the current scene is reset
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


        //Jumps using the spacebar as long as the player is on the ground
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsGrounded())
            {
                return;
            }
            else
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }

    }


    //Used to determine if the player is grounded
    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 2.0f;

        //Creates a raycast from the player's position downwards by the given distance to detect whether the player is on the ground layer
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);

        //If the raycast collides with the ground level, grounded is set to true
        if (hit.collider != null)
        {
            return true;
        }
        //sets grounded to false by default
        return false;
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
