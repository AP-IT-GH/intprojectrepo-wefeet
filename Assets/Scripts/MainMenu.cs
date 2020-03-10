using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 

    public void PlayDiscoGame()
    {       
        SceneManager.LoadScene("DanceGameScene",LoadSceneMode.Single); // Nog aan te passen van zodra merge van branch gebeurd is ! 
        // SceneManager.UnloadScene("MenuScene");
    }

    public void PlayCinemaGame()
    {
        SceneManager.LoadScene("DanceGameScene", LoadSceneMode.Single); // Nog aan te passen van zodra merge van branch gebeurd is !
        // SceneManager.UnloadScene("MenuScene");
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");

        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game

        Application.Quit();
        EditorApplication.isPlaying = false;

    }
}
