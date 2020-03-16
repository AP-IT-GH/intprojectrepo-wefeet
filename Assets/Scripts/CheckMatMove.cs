using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatMove : MonoBehaviour
{
    private MatInputController Mat = new MatInputController();
    private int currentMove = 0;
    private int score = 0;

    public int Score { get => score; }


    void Start()
    {
        score = 0;
        currentMove = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Mat.Update();
        float currentTime = Time.time;

        #region both feet center at 0 seconds
        //3 seconds time to complete the move
        if(currentTime < 3)
        {
            if(currentMove == 0)
            {
                if (Mat.Center)
                {
                    CorrectMove();
                }
            }
        }
        else
        {
            if(currentMove == 0)
            {
                IncorrectMove();
            }
        }
        #endregion

        #region 1 foot left and 1 foot right at 10 seconds
        //3 seconds time to complete the move
        if (currentTime > 9 && currentTime < 12)
        {
            if(currentMove == 1)
            {
                if(Mat.Left && Mat.Right)
                {
                    CorrectMove();
                }
            }
        }
        else
        {
            if (currentMove == 1 && currentTime > 12)
            {
                IncorrectMove();
            }
        }
        #endregion
    }

    private void IncorrectMove()
    {
        currentMove++;
        Debug.Log("INCORRECT MOVE");
    }

    private void CorrectMove()
    {
        score++;
        currentMove++;
        Debug.Log("SCORE: " + score);
    }
}
