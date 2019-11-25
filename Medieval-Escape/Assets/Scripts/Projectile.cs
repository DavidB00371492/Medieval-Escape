using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;

    public AudioClip ShootingSound;
    public AudioSource ShotSource;

    // Start is called before the first frame update
    void Start()
    {
        ShotSource.clip = ShootingSound;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Destroy"))
        {
            ShotSource.Play();
            DestroyProjectile();
        }

        if (collision.CompareTag("dam"))
        {
            DestroyProjectile();
        }
    }


    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
