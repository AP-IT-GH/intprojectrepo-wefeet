using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGB_light : MonoBehaviour
{
    //https://docs.unity3d.com/ScriptReference/Light-color.html

    // Interpolate light color between two colors back and forth
    float duration = 1.0f;
    Color color0 = Color.red;
    Color color1 = Color.blue;

    Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Darken the light completely over a period of 2 seconds.
    void Update()
    {
        //lt.color -= (Color.white / 2.0f) * Time.deltaTime;

        // set light color
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(color0, color1, t);
    }

}
