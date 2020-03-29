using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showScore : MonoBehaviour
{
    public changeText textField;
    public CheckMatMoveCinema scoreScript;

    int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score = scoreScript.Score;
        textField.changeScore(score);
    }
}
