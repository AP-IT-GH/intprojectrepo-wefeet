using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BackGroundMusic;

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
}
