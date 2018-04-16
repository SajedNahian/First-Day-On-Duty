using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayButton ()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void AboutButton ()
    {
        SceneManager.LoadScene("About");
    }

    public void ReturnToMainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
