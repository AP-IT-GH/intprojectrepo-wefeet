using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showScore : MonoBehaviour
{
    public changeText textField;
    public DanceMonkey scoreScript1;
    public ChaChaSlide scoreScript2;
    public playCustomSong scoreScriptDefault;

    int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (scoreScript1 != null) score = scoreScript1.Score;
        else if (scoreScript2 != null) score = scoreScript2.Score;
        //default
        else if (scoreScriptDefault != null) score = scoreScriptDefault.Score;
        //anders script afsluiten
        else Destroy(this);

        textField.changeScore(score);
    }
}
