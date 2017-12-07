using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{

    private GameObject[] pauseObjects;

    void Start()
    {

        Time.timeScale = 1; // if equal to 1 game is not paused, else if equal to 0 game is paused 
        pauseObjects = GameObject.FindGameObjectsWithTag("showOnPause"); // finds all objcts with tag showOnPause and stores them in an array
        hidePaused(); // calls method that hides all objects in the array 

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))  // checks to see if P has been pressed
        {
            if (Time.timeScale == 1)  // if game not paused, pause game and show pause objects 
            {
                Time.timeScale = 0;
                showPaused ();  
            }

            else if (Time.timeScale == 0) // if game paused, hides pause objects and un pauses the game 
            {
                hidePaused();
                Time.timeScale = 1;
            }
        }
    }

    // method which shows all objects in the pause objects array 

    private void showPaused()
    {

        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    // method which hides all objects in the pause objects array 

    private void hidePaused()
    {

        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }

    }
}
