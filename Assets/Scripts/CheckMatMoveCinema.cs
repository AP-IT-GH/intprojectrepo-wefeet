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
    private Move.moveResponse requiredMove;


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

        #region template
        /*requiredMove = Move.Moves(currentMove, *movenr*, currentTime, *begintime*, *endtime*, Mat, *string move*);
        checkMove(requiredMove);*/
        #endregion

        #region both feet center at 0 seconds
        /*//3 seconds time to complete the move
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
        //OR
        requiredMove = Move.Moves(currentMove, 1, currentTime, 0, 3, Mat);
        switch (requiredMove)
        {
            case Move.moveResponse.Correct:
                CorrectMove();
                break;
            case Move.moveResponse.Incorrect:
                IncorrectMove();
                break;
            default:
                //waiting, do nothing
                break;
        }*/
        #endregion

        #region 0
        requiredMove = Move.Moves(currentMove, 0, currentTime, 7, 9, Mat, "101000000");
        checkMove(requiredMove);
        #endregion

        #region 1
        requiredMove = Move.Moves(currentMove, 1, currentTime, 9, 11, Mat, "000101000");
        checkMove(requiredMove);
        #endregion

        #region 2
        requiredMove = Move.Moves(currentMove, 2, currentTime, 11, 14, Mat, "000000101");
        checkMove(requiredMove);
        #endregion

        #region 3
        requiredMove = Move.Moves(currentMove, 3, currentTime, 14, 22, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 4
        requiredMove = Move.Moves(currentMove, 4, currentTime, 22, 24, Mat, "000100000");
        checkMove(requiredMove);
        #endregion

        #region 5
        requiredMove = Move.Moves(currentMove, 5, currentTime, 24, 28, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 6
        requiredMove = Move.Moves(currentMove, 6, currentTime, 28, 30, Mat, "000011000");
        checkMove(requiredMove);
        #endregion

        #region 7
        requiredMove = Move.Moves(currentMove, 7, currentTime, 30, 32, Mat, "000110000");
        checkMove(requiredMove);
        #endregion

        #region 8
        requiredMove = Move.Moves(currentMove, 8, currentTime, 32, 33, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 9
        requiredMove = Move.Moves(currentMove, 9, currentTime, 33, 34, Mat, "101000000");
        checkMove(requiredMove);
        #endregion

        #region 10
        requiredMove = Move.Moves(currentMove, 10, currentTime, 34, 35, Mat, "000101000");
        checkMove(requiredMove);
        #endregion

        #region 11
        requiredMove = Move.Moves(currentMove, 11, currentTime, 35, 36, Mat, "000000101");
        checkMove(requiredMove);
        #endregion

        #region 12
        requiredMove = Move.Moves(currentMove, 12, currentTime, 36, 38, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 13
        requiredMove = Move.Moves(currentMove, 13, currentTime, 38, 39, Mat, "000100000");
        checkMove(requiredMove);
        #endregion

        #region 14
        requiredMove = Move.Moves(currentMove, 14, currentTime, 39, 42, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 15
        requiredMove = Move.Moves(currentMove, 15, currentTime, 42, 44, Mat, "000011000");
        checkMove(requiredMove);
        #endregion

        #region 16
        requiredMove = Move.Moves(currentMove, 16, currentTime, 44, 48, Mat, "000110000");
        checkMove(requiredMove);
        #endregion

        #region 17
        requiredMove = Move.Moves(currentMove, 17, currentTime, 48, 53, Mat, "000010000");
        checkMove(requiredMove);
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
    private void checkMove(Move.moveResponse requiredMove)
    {
        switch (requiredMove)
        {
            case Move.moveResponse.Correct:
                CorrectMove();
                break;
            case Move.moveResponse.Incorrect:
                IncorrectMove();
                break;
            default:
                //waiting, do nothing
                break;
        }
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


public static class Move
{
    public enum moveResponse
    {
        Correct,
        Incorrect,
        Waiting
    }

    public static moveResponse Moves(int currentMove, int moveNumber, float currentTime, float beginTime, float endTime, MatInputController Mat, string requiredMove)
    {
        if (currentTime > beginTime && currentTime < endTime)
        {
            if (currentMove == moveNumber)
            {
                List<bool> moves = new List<bool>();
                foreach (char item in requiredMove)
                {
                    if (item == '0')
                    {
                        moves.Add(false);
                    }
                    else if(item == '1')
                    {
                        moves.Add(true);
                    }
                    
                }
                if (Mat.LeftForward == moves[0] && 
                    Mat.Forward == moves[1] && 
                    Mat.RightForward == moves[2] && 
                    Mat.Left == moves[3] &&
                    Mat.Center == moves[4] &&
                    Mat.Right == moves[5] &&
                    Mat.LeftBackward == moves[6] &&
                    Mat.Backward == moves[7] &&
                    Mat.RightBackward == moves[8])
                {
                    return moveResponse.Correct;
                }
                else
                {
                    return moveResponse.Waiting; //allowed to make the move but havent made it yet
                }
            }
            else
            {
                return moveResponse.Waiting;
            }
        }
        else
        {
            if (currentMove == moveNumber && currentTime > endTime)
            {
                return moveResponse.Incorrect;
            }
            else
            {
                return moveResponse.Waiting;
            }
        }
    }
}
