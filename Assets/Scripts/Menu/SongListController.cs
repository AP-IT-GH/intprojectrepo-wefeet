using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongListController : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;
    private ArrayList TestSongs = new ArrayList();    
    private string[] songNames = new string[] { };
    private ArrayList pathToSongs = new ArrayList();

    public bool makeCostumsSongs = false;
    public bool playCostumSongs = false;

    AudioManager audioManager;


    void Start()
    {
        //zoek de audiuomanager
        audioManager = FindObjectOfType<AudioManager>();

        /*
         * Kijk wat er geselecteerd is
         * Kijk wat het path is
         * kijk wat de song naam is
         */
        if (playCostumSongs)
        {
            pathToSongs = findSongs.MadeSongs();
            songNames = GetNamesSong(pathToSongs);
        }            
        else if (makeCostumsSongs)
        {
            pathToSongs = findSongs.songsInProject;
            songNames = GetNamesSong(pathToSongs);
        }            
        else if (!playCostumSongs || !playCostumSongs) {
            initTestArrayList();
            songNames = GetNamesSong(TestSongs);
        }

        //maak de button voor de lijst aan en voeg alles toe
        for (int numberSong = 0; numberSong < songNames.Length; numberSong++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<SongListButton>().SetText(songNames[numberSong]);
            button.GetComponent<SongListButton>().initSong(pathToSongs[numberSong].ToString());

            button.transform.SetParent(buttonTemplate.transform.parent, false);
            
        }    
    }

    /// <summary>
    /// Wat moet er gebeuren als er op de knop wordt gedrukt
    /// </summary>
    /// <param name="myTextString">Test text</param>
    /// <param name="path">Path naar de file</param>
    /// <param name="songName">De naam van de song</param>
    public void ButtonClicked(string myTextString, string path, string songName)
    {
        //Give GameManger the name of the song
        Debug.Log(songName);
        ManageGame.SongName = songName;

        string tempPath = Application.streamingAssetsPath + "/sound/";

        //let the GameManager know what you wanne do. Create a Dance or play a Dance
        if (makeCostumsSongs) {
            ManageGame.CreateCostumSong = true;
            audioManager.changeAudioWithFile(path, songName);
        }           
        else if (playCostumSongs) {
            ManageGame.PlayCostumSong = true;
            audioManager.changeAudioWithFile(path, songName+".wav");
        }
        
        SceneManager.LoadScene("CustomSongScene", LoadSceneMode.Single);
    }

    /// <summary>
    /// Krijg alleen de, naam van de song zonder path of extensie
    /// </summary>
    /// <param name="songs">Array met padden naar de files</param>
    /// <returns>List van alleen song namen</returns>
    string[] GetNamesSong(ArrayList songs)
    {
        List<string> listSongs = new List<string>();
        int numberSong = 0;
        //split string to get Song name
        foreach (string song in songs)
        {
            string[] tempSong = new string[] { };
            tempSong = song.Split('\\');
            listSongs.Add(numberSong + " " + tempSong[tempSong.Length - 1].Remove(tempSong[tempSong.Length - 1].Length - 4, 4));
            numberSong++;
        }
        return listSongs.ToArray();
    }

    //Initialiseer de test Array (voor als er geen nummers in de andere Array zijn
    private void initTestArrayList()
    {
        Debug.Log("init test songs");
        TestSongs.Add(@"c:\test\test\song.mp3");
        TestSongs.Add(@"c:\test\test\song1.mp3");
        TestSongs.Add(@"c:\test\test\song2.mp3");
        TestSongs.Add(@"c:\test\test\song3.mp3");
        TestSongs.Add(@"c:\test\test\song4.mp3");
        TestSongs.Add(@"c:\test\test\song5.mp3");
        TestSongs.Add(@"c:\test\test\ChaCha.mp3");
        TestSongs.Add(@"c:\test\test\Dance_Monkey.mp3");
        TestSongs.Add(@"c:\test\test\randomLongSongNameToTest.mp3");
    }
}
