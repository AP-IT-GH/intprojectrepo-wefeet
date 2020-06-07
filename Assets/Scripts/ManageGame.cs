using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour
{
    private static bool createCostumSong = false;
    private static bool playCostumSong = false;
    private static string songName = "";

    private GameObject Create;
    private GameObject Play;

    // Start is called before the first frame update
    void Start()
    {
        //Zorg er voor dat ManageGame niet wordt verwijderd maar als er all 1 is wordt de nieuwste verwijderd
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType<ManageGame>().Length > 1)
            Destroy(gameObject);

        //add event to OnSceneLoaded
        SceneManager.sceneLoaded += OnSceneLoaded;        
    }

    //Functie die wordt toegevoegd als er een scene is geladen
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject.FindGameObjectWithTag("mainMenuTag").SetActive(false);
        if (scene.name == "CustomSongScene")
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            StartCostumSongScene();
        }
    }

    //Properties
    public static bool CreateCostumSong
    {
        get { return createCostumSong; }
        set { 
            createCostumSong = value;
            playCostumSong = !value;
        }
    }
    public static bool PlayCostumSong
    {
        get { return playCostumSong; }
        set { 
            playCostumSong = value;
            createCostumSong = !value;
        }
    }
    public static string SongName
    {
        get { return songName; }
        set { songName = value; }
    }

    private void StartCostumSongScene()
    {
        //Zoek GameObject aan de hand van een tag
        Play = GameObject.FindGameObjectWithTag("PlayCostumSong");
        Create = GameObject.FindGameObjectWithTag("CreateCostumSong");

        if (createCostumSong)
        {
            //Zet het Object PlayCostumSong uit
            Play.SetActive(false);
            //zoek in het GameObject naar het component (het script in dit geval) RecordCustomSong en verander de variable song
            Create.gameObject.GetComponent<RecordCustomSong>().song = songName;
        }
        else if (playCostumSong)
        {
            //Zet het Object CreateCostumSong uit
            Create.SetActive(false);
            //zoek in het GameObject naar het component (het script in dit geval) playCustomSong en verander de variable songname en voeg .wav.csv
            Play.gameObject.GetComponent<playCustomSong>().csvName = songName + ".wav.csv";
        }
    }
}
