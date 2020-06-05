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
        Debug.Log("Start GameManager");
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType<ManageGame>().Length > 1)
            Destroy(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;

        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
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
        //werkt maar op een rare manier (raad het niet aan)
        //GameObject gameObj = GameObject.Find("playTrigger");
        //gameObj.GetComponent<RecordCustomSong>().enabled = true;
        //gameObj.GetComponent<playCustomSong>().enabled = true;
        //gameObj.GetComponent<showScore>().enabled = false;

        Play = GameObject.FindGameObjectWithTag("PlayCostumSong");
        Create = GameObject.FindGameObjectWithTag("CreateCostumSong");

        if (createCostumSong)
        {
            Debug.Log("Create Costum song");
            Play.SetActive(false);
            //Create.SetActive(true);

            Create.gameObject.GetComponent<RecordCustomSong>().song = songName;
        }
        else if (playCostumSong)
        {
            Debug.Log("Play Costum song");
            //Play.SetActive(true);
            Create.SetActive(false);
        }
    }
}
