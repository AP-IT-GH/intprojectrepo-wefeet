using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatMoveCinema : MonoBehaviour
{
    private MatInputController Mat = new MatInputController();
    private int currentMove = 0;
    private int score = 0;

    [Header("Add the 9 tiles")]
    [Tooltip("start by the top left tile, then the one to the right and so on, then move down a row")]
    public GameObject[] tiles;

    public int Score { get => score; }


    void Start()
    {
        Mat.Start();
        score = 0;
        currentMove = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Mat.Update();
        float currentTime = Time.time;

        ShowFeet();

        #region both feet center at 0 seconds
        //3 seconds time to complete the move
        if (currentTime < 3)
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

    private void ShowFeet() //visually show where your feet are
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].SetActive(false);
        }
        if (Mat.LeftForward) tiles[0].SetActive(true);
        if (Mat.Forward) tiles[1].SetActive(true);
        if (Mat.RightForward) tiles[2].SetActive(true);
        if (Mat.Left) tiles[3].SetActive(true);
        if (Mat.Center) tiles[4].SetActive(true);
        if (Mat.Right) tiles[5].SetActive(true);
        if (Mat.LeftBackward) tiles[6].SetActive(true);
        if (Mat.Backward) tiles[7].SetActive(true);
        if (Mat.RightBackward) tiles[8].SetActive(true);
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
