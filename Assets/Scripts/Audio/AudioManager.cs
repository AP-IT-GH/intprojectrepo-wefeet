using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BackGroundMusic;
    private AudioClip audioClip;

    private string AudioPath;
    private string AudioName;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType<AudioManager>().Length > 1)
            Destroy(gameObject);
    }

    /// <summary>
    /// Verander de muziek op de achtergrond
    /// </summary>
    /// <param name="music">Welke audio clip moet worden afgespeeld</param>
    public void ChangeBackGroundMusic(AudioClip music)
    {
        //if there is a trigger that will play the same music file. It won't trigger
        if (BackGroundMusic.clip.name == music.name) 
            return;

        BackGroundMusic.Stop(); //Stop de muziek
        BackGroundMusic.clip = music; //Verander de muziek
        BackGroundMusic.Play(); //Speel de muziek af
    }

    /// <summary>
    /// Verander de muziek aan met audio die in een file staat
    /// </summary>
    /// <param name="Path">Geef het path naar de audio file</param>
    /// <param name="audioName">Wat is de naam van de audio file</param>
    public void changeAudioWithFile(string Path, string audioName)
    {
        AudioPath = "file://" + Path;
        AudioName = audioName;
        BackGroundMusic.Pause();
                
        StartCoroutine(loadAudio()); //Deze code blijft uitgevoerd worden tot de yield iets terug geeft
    }

    /// <summary>
    /// laad de audio vanuit een file
    /// voor code uit en wacht tot een return krijgt
    /// die wordt gecheckt na elke thread
    /// </summary>
    /// <returns></returns>
    private IEnumerator loadAudio()
    {
        WWW request = GetAudioFromFile(AudioPath, AudioName); //Start de request

        yield return request; //stuur request terug als er iets gevonden is

        audioClip = request.GetAudioClip();
        ChangeBackGroundMusic(audioClip);
    }

    /// <summary>
    /// Gaat de audio file downloaden en terug sturen
    /// </summary>
    /// <param name="path">Path naar de file</param>
    /// <param name="Filename">De naam van de file</param>
    /// <returns></returns>
    public WWW GetAudioFromFile(string path, string Filename)
    {
        //Debug.Log("Do request for song: " + path + Filename);                                                                           
        string AudioToLoad = string.Format(path + Filename);
        WWW reqeust = new WWW(AudioToLoad);
        return reqeust;

    }
}
