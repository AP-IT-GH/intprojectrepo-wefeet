using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    public AudioClip[] ricochet; // The array controlling the sounds
    public int rayMax; // The max amount of Sounds there are
    public int pickedSound; // The sound is choose to play
    // Use this for initialization
    void Start()
    {
        pickedSound = Random.Range(0, rayMax); // Grab a random sound out of the max
        gameObject.GetComponent<AudioSource>().clip = ricochet[pickedSound]; // Tell the AudioSource to become that sound
    }

    // Update is called once per frame
    void Update()
    {

    }
}