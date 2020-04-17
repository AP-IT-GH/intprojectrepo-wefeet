using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showScore : MonoBehaviour
{
    public changeText textField;
    public DanceMonkey scoreScript1;
    public ChaChaSlide scoreScript2;

    int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(scoreScript1 != null) score = scoreScript1.Score;
        else if (scoreScript2 != null) score = scoreScript2.Score;

        textField.changeScore(score);
    }
}
