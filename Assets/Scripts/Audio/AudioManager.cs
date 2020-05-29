using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BackGroundMusic;
    private AudioClip audioClip;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType<AudioManager>().Length > 1)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeBackGroundMusic(AudioClip music)
    {
        //if there is a trigger that will play the same music file. It won't trigger
        if (BackGroundMusic.clip.name == music.name) 
            return;

        BackGroundMusic.Stop();
        BackGroundMusic.clip = music;
        BackGroundMusic.Play();
    }

    public void changeAudioWithFile(string Paht, string audioName)
    {
        string soundPath = "file://" + Paht;
        loadAudio(soundPath, audioName); 
    }

    private IEnumerable loadAudio(string PahtTosong, string audioName)
    {        
        WWW request = GetAudioFromFile(PahtTosong, audioName);
        yield return request;
                
        audioClip = request.GetAudioClip();
        audioClip.name = audioName;
        BackGroundMusic.Pause();
        BackGroundMusic.clip = audioClip;
        BackGroundMusic.Play();
    }

    public WWW GetAudioFromFile(string path, string Filename)
    {
        string AudioToLoad = string.Format(path + Filename);
        WWW reqeust = new WWW(AudioToLoad);
        return reqeust;

    }
}
