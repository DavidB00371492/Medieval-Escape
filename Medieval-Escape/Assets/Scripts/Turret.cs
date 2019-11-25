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

    // Start is called before the first frame update
    void Start()
    {
        timebetweenshots = startnextShot;
        SoundSource.clip = ShotSound;
    }

    // Update is called once per frame
    void Update()
    {
        if(timebetweenshots <= 0)
        {
            Instantiate(arrow, transform.position, Quaternion.identity);
            SoundSource.Play();
            Debug.Log("hELLOW");
            timebetweenshots = startnextShot;
        }
        else
        {
            timebetweenshots -= Time.deltaTime;
        }
    }
}
