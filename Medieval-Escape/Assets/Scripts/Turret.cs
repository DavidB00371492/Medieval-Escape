using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public AudioSource SoundSource;
    public AudioClip ShotSound;

    float timebetweenshots;
    float startnextShot = 2f;

    public GameObject arrow;

    
    void Start()
    {
        //Sets the timer total
        timebetweenshots = startnextShot;
        SoundSource.clip = ShotSound;
    }

    // Update is called once per frame
    void Update()
    {
        //if the timer runs out the arrow is created, a sound is played and the timer restarts, otherwise the timer counts down
        if(timebetweenshots <= 0)
        {
            Instantiate(arrow, transform.position, Quaternion.identity);
            SoundSource.Play();
            timebetweenshots = startnextShot;
        }
        else
        {
            timebetweenshots -= Time.deltaTime;
        }
    }
}
