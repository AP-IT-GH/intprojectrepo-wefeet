using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour
{
    private static bool createCostumSong = false;
    private static bool playCostumSong = false;

    

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
        Debug.Log("switch scene detected");
        Debug.Log("scene: " + scene.name);
        if (scene.name == "CustomSongScene")
        {
            Debug.Log("your in costumSongScene");
            Debug.Log("createCostumSong: " + createCostumSong);
            Debug.Log("playCostumSong: " + playCostumSong);
        }
    }

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

}
