using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float ShotTime = 3.0f;
    public GameObject bulletPrefab;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShotTime -= Time.deltaTime;

        //When the shot time reaches zero, the timer is reset and the shoot function is executed
        if (ShotTime <= 0.0f)
        {
            ShotTime = 3.0f;
            Shoot();
        }
    }

    //Creates a bullet from the bullet prefab and uses the position and rotation of the bullet's fire position
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    //Destroys the enemy object when executed
    public void Die()
    {
        Destroy(gameObject);
    }
}
