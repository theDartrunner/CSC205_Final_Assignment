using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scChanger : MonoBehaviour {

	
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
        SceneManager.LoadScene("level");
    }
    
    public void howTo()
    {
        SceneManager.LoadScene("howToPlay");
    }
}
