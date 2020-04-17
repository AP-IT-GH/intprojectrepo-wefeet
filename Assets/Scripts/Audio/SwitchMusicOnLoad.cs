using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicOnLoad : MonoBehaviour
{
    public AudioClip NewTrack;
    public bool StopMusicOnLoad;

    private AudioManager AudioManager;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager = FindObjectOfType<AudioManager>();
        if(NewTrack != null)
            AudioManager.ChangeBackGroundMusic(NewTrack);
        if (StopMusicOnLoad)
            AudioManager.BackGroundMusic.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
