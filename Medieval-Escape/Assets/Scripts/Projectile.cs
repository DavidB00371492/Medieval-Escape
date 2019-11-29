using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;

    //public AudioClip ShootingSound;
    //public AudioSource ShotSource;

    // Start is called before the first frame update
    void Start()
    {
        //ShotSource.clip = ShootingSound;
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the arrow right by default
        transform.Translate(Vector2.right * speed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player collides with an object tagged 'Damage', the current scene is reset
        if (collision.gameObject.CompareTag("Destroy"))
        {
            DestroyProjectile();
        }
    }
    //Destroys the projectile when colliding with and object tagged "dam"
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dam"))
        {
            DestroyProjectile();
        }
    }

    //Destroys the arrow when executed
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
