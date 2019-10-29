using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;  
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroys the bullet object when colliding with any object
        Destroy(gameObject);

        //If the bullet collides with the player object, the current scene is reset
        //This should be altered if a health system is implemented
        if(collision.gameObject.name.Equals("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
