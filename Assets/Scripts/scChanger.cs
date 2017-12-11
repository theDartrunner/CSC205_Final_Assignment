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
    public void Level2 ()
    {
        SceneManager.LoadScene("level_2");
    }
    public void Tutorial ()
    {
        SceneManager.LoadScene("Tutorial_level");
    }
    public void about()
    {
        SceneManager.LoadScene("about");
    }
    public void newGame()
    {
        SceneManager.LoadScene("level_select");
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
