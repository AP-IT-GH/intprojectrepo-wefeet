using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer Mixer;
    public string NameOfVolumeMixer;

    public void Start()
    {
        if(NameOfVolumeMixer == null)
            NameOfVolumeMixer = "MasterVol";
    }

    public void SetLevel(float sliderValue)
    {
        //Mixer.SetFloat("MusicVol", sliderValue); //Je moet de float nog omvormen naar een logaritmise waarde
        Mixer.SetFloat(NameOfVolumeMixer, Mathf.Log10(sliderValue)*20);

    }
}
