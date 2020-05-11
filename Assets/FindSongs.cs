using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FindSongs : MonoBehaviour
{
    //LAAD SCRIPT MOMENTEEL NIET, LAAT NIETS ZIEN IN CONSOLE
    ArrayList songs = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        System.Console.WriteLine("Music path: "+ path);

        foreach (string file in Directory.GetFiles(path, "*.mp3"))
        {
            songs.Add(file);
            System.Console.WriteLine("Nummer: " +file);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
