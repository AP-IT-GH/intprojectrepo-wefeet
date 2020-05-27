using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class findSongs : MonoBehaviour
{
    public static ArrayList songs = new ArrayList();
    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
    string result;
    public static ArrayList songsInProject = new ArrayList();
   

    void Start()
    {
        //ArrayList met alle namen
        foreach (string file in Directory.GetFiles(path, "*.mp3"))
        {
            result = Path.GetFileName(file);
            songs.Add(result);
        }

        //Alle files van C:\user\hans\music => kopieren naar => \Assets\StreamingAssets\Sound
        foreach (string file in songs)
        {
            //Debug.Log($"file: {file}");

            string str = Application.streamingAssetsPath + "/Sound/" + file.ToString();
            //Debug.Log($"str: {str}");
            //Debug.Log($@"From: {path}\{file}");

            if (!File.Exists(str))
            {
                File.Copy($@"{path}\{file}", str);
                //Debug.Log($"Copied from: --- {$@"{path}\{file}"} --- to --- {str} ---");
            }
            else { Debug.Log("File already excits"); }
        }

        foreach (string file in Directory.GetFiles(Application.streamingAssetsPath + "/Sound/", "*.mp3"))
        {
            result = Path.GetFileName(file);
            songsInProject.Add(result);
        }

        //MadeSongs();
    }
    
    public static ArrayList MadeSongs()
    {
        string temp;
       ArrayList madeSongs = new ArrayList();

        foreach (string file in Directory.GetFiles(@"songScripts\", "*.csv"))
        {
            temp = Path.GetFileName(file);
            madeSongs.Add(temp.Split('.')[0]);
            //Debug.Log("Song " +temp.Split('.')[0] + " made! ----------------------");
        }
        return madeSongs;
    }
}