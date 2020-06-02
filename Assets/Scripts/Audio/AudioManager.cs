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
    public void ChangeBackGroundMusic(AudioClip music)
    {
        //if there is a trigger that will play the same music file. It won't trigger
        if (BackGroundMusic.clip.name == music.name) 
            return;

        BackGroundMusic.Stop();
        BackGroundMusic.clip = music;
        BackGroundMusic.Play();
        Debug.Log("Audio Changed");
    }

    public void changeAudioWithFile(string Path, string audioName)
    {
        Debug.Log("Audio Change activated");
        AudioPath = "file://" + Path;
        AudioName = audioName;
        BackGroundMusic.Pause();
        StartCoroutine(loadAudio());
        Debug.Log("Audio Change done");
    }

    private IEnumerator loadAudio()
    {
        Debug.Log("before doing request");

        WWW request = GetAudioFromFile(AudioPath, AudioName);

        Debug.Log("request for song done");
        yield return request;

        audioClip = request.GetAudioClip();
        ChangeBackGroundMusic(audioClip);
    }

    public WWW GetAudioFromFile(string path, string Filename)
    {
        Debug.Log("Do request for song: " + path + Filename);
        string AudioToLoad = string.Format(path + Filename);
        //WWW reqeust = new WWW(AudioToLoad);
        Debug.Log(@"file://C://Users/quint/Music/BlindingLights.mp3");
        WWW reqeust = new WWW("file://C://Users/quint/Music/BlindingLights.mp3");
        return reqeust;

    }
}
