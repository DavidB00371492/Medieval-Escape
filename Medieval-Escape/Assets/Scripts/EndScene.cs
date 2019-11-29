using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    //Sets the timer totals
    private float timer = 15;


    void Start()
    {
        //Removes the background music object from the scene
        Destroy(GameObject.Find("BackgroundMusic"));
    }

    void Update()
    {
        //Counts down the timer
        timer -= Time.deltaTime;

        //Returns the player to the main menu if the player presses the escape key or 15 seconds have passed
        if (timer <= 0 ||(Input.GetKeyDown(KeyCode.Escape)))
        {
            SceneManager.LoadScene("Main Menu");
        }



    }
}