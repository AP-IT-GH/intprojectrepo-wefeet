using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    string SceneToLoad = "";

    public void PlayDiscoGame()
    {
        SceneToLoad = "Disco";
        //SceneManager.LoadScene("Disco",LoadSceneMode.Single); // Will be loaded after choosing song        
    }

    public void PlayCinemaGame()
    {
        SceneToLoad = "Assets/Scenes/Dance_Cinema/Dance_Cinema.unity";
        //SceneManager.LoadScene("Assets/Scenes/Dance_Cinema/Dance_Cinema.unity", LoadSceneMode.Single); // Will be loaded after choosing song
    }

    public void PlaySong1()
    {
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
    }

    public void PlaySong2()
    {
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
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
