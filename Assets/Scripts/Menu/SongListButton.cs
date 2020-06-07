using System.Collections;
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

    /// <summary>
    /// Zet de text van de knop juist
    /// </summary>
    /// <param name="textString"> Wat moet er staan op de knop</param>
    public void SetText(string textString)
    {
        myTextString = textString;
        myText.text = textString;
    }
    /// <summary>
    /// Wat gebeurt er alles er op de knop gedrukt wordt
    /// </summary>
    public void OnClick()
    {
        songListController.ButtonClicked(myTextString, pathToFolder, SongNameInFolder);
    }

    /// <summary>
    /// initialiseer de knop
    /// </summary>
    /// <param name="songNameInFolder">Wat is de naam van de song in de map</param>
    public void initSong(string songNameInFolder)
    {
        SongNameInFolder = songNameInFolder;
    }
    private void Awake()
    {
        //stel het path in naar de folder waar alle geimporteerde muziek staat
        pathToFolder = Application.streamingAssetsPath + "/sound/";
    }
}
