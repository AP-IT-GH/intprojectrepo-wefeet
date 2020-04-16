using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatMoveCinema : MonoBehaviour
{
    private MatInputController Mat = new MatInputController();
    private int currentMove = 0;
    private int score = 0;

    [Tooltip("offset between start of song and moves")]
    public float offset = 0;


    [Header("Add the 9 tiles")]
    [Tooltip("start by the top left tile, then the one to the right and so on, then move down a row")]
    public GameObject[] tiles;

    public int Score { get => score; }

    [Header("Changing lights")]
    [Tooltip("these light change color and give feedback with a good or bad move")]
    public List<Light> lights;
    private float timer = float.MaxValue;

    private Move.moveResponse requiredMove;
    private bool endedConnection = false;
    private float startTime;


    void Start()
    {
        GameObject screen = GameObject.FindWithTag("screen");
        screen.SetActive(true);
        Mat.Start();
        score = 0;
        currentMove = 0;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Mat.Update();
        float currentTime = Time.time - startTime;

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            changeLight(Color.white, float.MaxValue);
        }

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
        requiredMove = Move.Moves(currentMove, 0, currentTime, 18.6f, 20.6f, offset, Mat, "101000000");
        checkMove(requiredMove);
        #endregion

        #region 1
        requiredMove = Move.Moves(currentMove, 1, currentTime, 20.6f, 22.9f, offset, Mat, "000101000");
        checkMove(requiredMove);
        #endregion

        #region 2
        requiredMove = Move.Moves(currentMove, 2, currentTime, 22.9f, 25.8f, offset, Mat, "000000101");
        checkMove(requiredMove);
        #endregion

        #region 3
        requiredMove = Move.Moves(currentMove, 3, currentTime, 25.8f, 34.2f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 4
        requiredMove = Move.Moves(currentMove, 4, currentTime, 34.2f, 36.2f, offset, Mat, "000100000");
        checkMove(requiredMove);
        #endregion

        #region 5
        requiredMove = Move.Moves(currentMove, 5, currentTime, 36.2f, 40.1f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 6
        requiredMove = Move.Moves(currentMove, 6, currentTime, 40.1f, 42.3f, offset, Mat, "000011000");
        checkMove(requiredMove);
        #endregion

        #region 7
        requiredMove = Move.Moves(currentMove, 7, currentTime, 42.3f, 44.4f, offset, Mat, "000110000");
        checkMove(requiredMove);
        #endregion

        #region 8
        requiredMove = Move.Moves(currentMove, 8, currentTime, 44.4f, 45.6f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 9
        requiredMove = Move.Moves(currentMove, 9, currentTime, 45.6f, 46.9f, offset, Mat, "101000000");
        checkMove(requiredMove);
        #endregion

        #region 10
        requiredMove = Move.Moves(currentMove, 10, currentTime, 46.9f, 47.9f, offset, Mat, "000101000");
        checkMove(requiredMove);
        #endregion

        #region 11
        requiredMove = Move.Moves(currentMove, 11, currentTime, 47.9f, 49.0f, offset, Mat, "000000101");
        checkMove(requiredMove);
        #endregion

        #region 12
        requiredMove = Move.Moves(currentMove, 12, currentTime, 49.0f, 51.1f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 13
        requiredMove = Move.Moves(currentMove, 13, currentTime, 51.1f, 52.2f, offset, Mat, "000100000");
        checkMove(requiredMove);
        #endregion

        #region 14
        requiredMove = Move.Moves(currentMove, 14, currentTime, 52.2f, 55.3f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 15
        requiredMove = Move.Moves(currentMove, 15, currentTime, 55.3f, 57.4f, offset, Mat, "000011000");
        checkMove(requiredMove);
        #endregion

        #region 16
        requiredMove = Move.Moves(currentMove, 16, currentTime, 57.4f, 61.4f, offset, Mat, "000110000");
        checkMove(requiredMove);
        #endregion

        #region 17
        requiredMove = Move.Moves(currentMove, 17, currentTime, 61.4f, 67.5f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        //close connection after final move and destroy this script
        if(currentMove == 18 && endedConnection == false)
        {
            Mat.CloseConnection();
            endedConnection = true;

            changeLight(Color.white, float.MaxValue);
            Destroy(this);
        }

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

        //change light color to red for 0.5s
        changeLight(Color.red, 0.5f);
    }

    private void CorrectMove()
    {
        score++;
        currentMove++;
        Debug.Log("SCORE: " + score);

        //change light to green for 0.5s
        changeLight(Color.green, 0.5f);
    }

    private void changeLight(Color color, float duration)
    {
        timer = duration;
        foreach (Light item in lights)
        {
            item.color = color;
        }
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

    public static moveResponse Moves(int currentMove, int moveNumber, float currentTime, float beginTime, float endTime, float offset, MatInputController Mat, string requiredMove)
    {
        if (currentTime > beginTime + offset && currentTime < endTime + offset)
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
            if (currentMove == moveNumber && currentTime > endTime + offset)
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
