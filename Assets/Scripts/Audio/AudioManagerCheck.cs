using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerCheck : MonoBehaviour
{
    public GameObject AudioManager;

    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<AudioManager>())
            return;
        else
            Instantiate(AudioManager, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
