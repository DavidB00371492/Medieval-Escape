using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneTimer : MonoBehaviour
{
    //Sets the timer to 18 seconds
    private float timer = 15;


    void Start()
    {
        
    }

    void Update()
    {
        //Counts down the timer
        timer -= Time.deltaTime;

        //If the timer reaches zero or the player presses escape, the player is returned to the main menu
        if(timer <= 0 || (Input.GetKeyDown(KeyCode.Escape)))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
