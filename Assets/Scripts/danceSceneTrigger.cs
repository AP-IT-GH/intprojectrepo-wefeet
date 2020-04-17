using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danceSceneTrigger : MonoBehaviour
{
    public GameObject chacha;
    public GameObject danceMonkey;
    void Start()
    {
        if(NavBuffer.SongToLoad == "chacha")
        {
            chacha.SetActive(true);
        }
        else if(NavBuffer.SongToLoad == "danceMonkey")
        {
            danceMonkey.SetActive(true);
        }
    }
}
