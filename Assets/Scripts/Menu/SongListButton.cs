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

    public void SetText(string textString)
    {
        myTextString = textString;
        myText.text = textString;
    }
    public void OnClick()
    {
        SceneManager.LoadScene("CustomSongScene", LoadSceneMode.Single);
        //SceneManager.LoadScene("Disco", LoadSceneMode.Single);
        songListController.ButtonClicked(myTextString);
    }
}
