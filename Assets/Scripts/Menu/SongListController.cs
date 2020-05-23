using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongListController : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;
    private string[] TestSongs = new string[]{
        @"c:\test\test\song.mp3",
        @"c:\test\test\song1.mp3",
        @"c:\test\test\song2.mp3",
        @"c:\test\test\song3.mp3",
        @"c:\test\test\song4.mp3",
        @"c:\test\test\song5.mp3",
        @"c:\test\test\randomLongSongNameToTest.mp3",
        @"c:\test\test\ChaCha.mp3",
        @"c:\test\test\Dance_Monkey.mp3",
    };
    private string[] songNames = new string[] { };

    void Start()
    {
        songNames = GetNamesSong(TestSongs);

        foreach (string song in songNames)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<SongListButton>().SetText(song);

            button.transform.SetParent(buttonTemplate.transform.parent, false);


        }    
    }

    //what needs to happen when you press the button
    public void ButtonClicked(string myTextString)
    {
        Debug.Log(myTextString);
    }

    //Get the song names out of the path's
    string[] GetNamesSong(string[] songs)
    {
        List<string> listSongs = new List<string>();

        //split string to get Song name
        foreach (string item in songs)
        {
            string[] tempSong = new string[] { };
            tempSong = item.Split('\\');
            listSongs.Add(tempSong[tempSong.Length - 1].Remove(tempSong[tempSong.Length - 1].Length - 4, 4));
        }
        return listSongs.ToArray();
    }
}
