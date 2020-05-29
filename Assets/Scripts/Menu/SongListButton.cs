﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SongListButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI myText;
    [SerializeField]
    private SongListController songListController;  

    private string myTextString;
    private string pathToFolder;
    private string SongNameInFolder;

    public void SetText(string textString)
    {
        myTextString = textString;
        myText.text = textString;
    }
    public void OnClick()
    {
        AudioManager AudioManager = FindObjectOfType<AudioManager>();
        AudioManager.loadAudio(pathToFolder, SongNameInFolder) ;
        songListController.ButtonClicked(myTextString);
    }
    public void initSong(string songNameInFolder)
    {
        SongNameInFolder = songNameInFolder;
        Debug.Log(SongNameInFolder);
    }
    private void Awake()
    {
        pathToFolder = Application.streamingAssetsPath + "/sound/";
    }
}
