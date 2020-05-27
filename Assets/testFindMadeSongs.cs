using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFindMadeSongs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in findSongs.MadeSongs())
        {
            Debug.Log("Made song: " + item + "------------------------------------");
        }
    }

    // Update is called once per frame
    void Update()
    {    
    }
}
