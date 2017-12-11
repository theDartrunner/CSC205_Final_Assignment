using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBehaviour : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Scene scene = SceneManager.GetActiveScene();

            if (scene.name == "tutorial_level")
            {
                SceneManager.LoadScene("level_2");
            } else if (scene.name == "level_2")
            {
                SceneManager.LoadScene("mainMenu");
            }
  
        }
    }
}
