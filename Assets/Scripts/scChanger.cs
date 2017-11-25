using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scChanger : MonoBehaviour {
    /* 
     * loads correct scene on button click 
     * to add a new scene make new method with scene name in " "
    */
	
	public void maninMenu ()
    {
        SceneManager.LoadScene("mainMenu");
    }
    public void highScroes ()
    {
        SceneManager.LoadScene("highScores");
    }
    public void about()
    {
        SceneManager.LoadScene("about");
    }
    public void newGame()
    {
        SceneManager.LoadScene("level1");
    }
    
    public void howTo()
    {
        SceneManager.LoadScene("howToPlay");
    }

    public void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
