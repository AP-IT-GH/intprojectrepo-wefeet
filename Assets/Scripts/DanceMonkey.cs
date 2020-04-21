using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceMonkey : MonoBehaviour
{
    private MatInputController Mat = new MatInputController();
    private int currentMove = 0;
    private int score = 0;

    [Tooltip("offset between start of song and moves")]
    public float offset = 0;

    public GameObject screen;


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
    bool begin = false;
    int numberOfMoves = 54;


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

        if (!begin)
        {
            startTime = Time.time;
            screen.SetActive(true);
        }
        begin = true;
        float currentTime = Time.time - startTime;

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            changeLight(Color.white, float.MaxValue);
        }

        ShowFeet();

        #region 0
        requiredMove = Move.Moves(currentMove, 0, currentTime, 20.5f, 22.23f, offset, Mat, "010000000");
        checkMove(requiredMove);
        #endregion

        #region 1
        requiredMove = Move.Moves(currentMove, 1, currentTime, 22.23f, 24.26f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 2
        requiredMove = Move.Moves(currentMove, 2, currentTime, 24.26f, 25.83f, offset, Mat, "000000010");
        checkMove(requiredMove);
        #endregion

        #region 3
        requiredMove = Move.Moves(currentMove, 3, currentTime, 25.83f, 27.43f, offset, Mat, "000000100");
        checkMove(requiredMove);
        #endregion

        #region 4
        requiredMove = Move.Moves(currentMove, 4, currentTime, 27.43f, 29.20f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 5
        requiredMove = Move.Moves(currentMove, 5, currentTime, 29.20f, 30.60f, offset, Mat, "100000000");
        checkMove(requiredMove);
        #endregion

        #region 6
        requiredMove = Move.Moves(currentMove, 6, currentTime, 30.6f, 32.03f, offset, Mat, "001000000");
        checkMove(requiredMove);
        #endregion

        #region 7
        requiredMove = Move.Moves(currentMove, 7, currentTime, 32.03f, 33.60f, offset, Mat, "000001000");
        checkMove(requiredMove);
        #endregion

        #region 8
        requiredMove = Move.Moves(currentMove, 8, currentTime, 33.60f, 35.10f, offset, Mat, "000000001");
        checkMove(requiredMove);
        #endregion

        #region 9
        requiredMove = Move.Moves(currentMove, 9, currentTime, 35.10f, 36.70f, offset, Mat, "000000010");
        checkMove(requiredMove);
        #endregion

        #region 10
        requiredMove = Move.Moves(currentMove, 10, currentTime, 36.7f, 40.93f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 11
        requiredMove = Move.Moves(currentMove, 11, currentTime, 40.93f, 42.90f, offset, Mat, "000101000");
        checkMove(requiredMove);
        #endregion

        #region 12
        requiredMove = Move.Moves(currentMove, 12, currentTime, 42.90f, 44.03f, offset, Mat, "101000000");
        checkMove(requiredMove);
        #endregion

        #region 13
        requiredMove = Move.Moves(currentMove, 13, currentTime, 44.03f, 45.80f, offset, Mat, "000101000");
        checkMove(requiredMove);
        #endregion

        #region 14
        requiredMove = Move.Moves(currentMove, 14, currentTime, 45.80f, 47.20f, offset, Mat, "000000101");
        checkMove(requiredMove);
        #endregion

        #region 15
        requiredMove = Move.Moves(currentMove, 15, currentTime, 47.20f, 49.30f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 16
        requiredMove = Move.Moves(currentMove, 16, currentTime, 49.30f, 50.90f, offset, Mat, "000101000");
        checkMove(requiredMove);
        #endregion

        #region 17
        requiredMove = Move.Moves(currentMove, 17, currentTime, 50.90f, 52.03f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 18
        requiredMove = Move.Moves(currentMove, 18, currentTime, 52.03f, 53.45f, offset, Mat, "010000000");
        checkMove(requiredMove);
        #endregion

        #region 19
        requiredMove = Move.Moves(currentMove, 19, currentTime, 53.45f, 54.70f, offset, Mat, "101000000");
        checkMove(requiredMove);
        #endregion

        #region 20
        requiredMove = Move.Moves(currentMove, 20, currentTime, 54.70f, 56.00f, offset, Mat, "010000000");
        checkMove(requiredMove);
        #endregion

        #region 21
        requiredMove = Move.Moves(currentMove, 21, currentTime, 56.00f, 57.10f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 22
        requiredMove = Move.Moves(currentMove, 22, currentTime, 57.10f, 58.30f, offset, Mat, "000000010");
        checkMove(requiredMove);
        #endregion

        #region 23
        requiredMove = Move.Moves(currentMove, 23, currentTime, 58.30f, 60.13f, offset, Mat, "000000101");
        checkMove(requiredMove);
        #endregion

        #region 24
        requiredMove = Move.Moves(currentMove, 24, currentTime, 60.13f, 62.40f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 25
        requiredMove = Move.Moves(currentMove, 25, currentTime, 62.40f, 64.50f, offset, Mat, "100001000");
        checkMove(requiredMove);
        #endregion

        #region 26
        requiredMove = Move.Moves(currentMove, 26, currentTime, 64.50f, 66.33f, offset, Mat, "001100000");
        checkMove(requiredMove);
        #endregion

        #region 27
        requiredMove = Move.Moves(currentMove, 27, currentTime, 66.33f, 67.60f, offset, Mat, "000100001");
        checkMove(requiredMove);
        #endregion

        #region 28
        requiredMove = Move.Moves(currentMove, 28, currentTime, 67.60f, 69.40f, offset, Mat, "000001100");
        checkMove(requiredMove);
        #endregion

        #region 29
        requiredMove = Move.Moves(currentMove, 29, currentTime, 69.40f, 70.73f, offset, Mat, "000000010");
        checkMove(requiredMove);
        #endregion

        #region 30
        requiredMove = Move.Moves(currentMove, 30, currentTime, 70.73f, 72.23f, offset, Mat, "000101000");
        checkMove(requiredMove);
        #endregion

        #region 31
        requiredMove = Move.Moves(currentMove, 31, currentTime, 72.23f, 73.46f, offset, Mat, "000000010");
        checkMove(requiredMove);
        #endregion

        #region 32
        requiredMove = Move.Moves(currentMove, 32, currentTime, 73.46f, 74.80f, offset, Mat, "010000000");
        checkMove(requiredMove);
        #endregion

        #region 33
        requiredMove = Move.Moves(currentMove, 33, currentTime, 74.80f, 76.13f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 34
        requiredMove = Move.Moves(currentMove, 34, currentTime, 76.13f, 77.60f, offset, Mat, "000101000");
        checkMove(requiredMove);
        #endregion

        #region 35
        requiredMove = Move.Moves(currentMove, 35, currentTime, 77.60f, 79.20f, offset, Mat, "101000000");
        checkMove(requiredMove);
        #endregion

        #region 36
        requiredMove = Move.Moves(currentMove, 36, currentTime, 79.20f, 80.40f, offset, Mat, "000101000");
        checkMove(requiredMove);
        #endregion

        #region 37
        requiredMove = Move.Moves(currentMove, 37, currentTime, 80.40f, 81.93f, offset, Mat, "101000000");
        checkMove(requiredMove);
        #endregion

        #region 38
        requiredMove = Move.Moves(currentMove, 38, currentTime, 81.93f, 83.25f, offset, Mat, "000101000");
        checkMove(requiredMove);
        #endregion

        #region 39
        requiredMove = Move.Moves(currentMove, 39, currentTime, 83.25f, 85.20f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 40
        requiredMove = Move.Moves(currentMove, 40, currentTime, 85.20f, 86.53f, offset, Mat, "010000000");
        checkMove(requiredMove);
        #endregion

        #region 41
        requiredMove = Move.Moves(currentMove, 41, currentTime, 86.53f, 87.93f, offset, Mat, "000000101");
        checkMove(requiredMove);
        #endregion

        #region 42
        requiredMove = Move.Moves(currentMove, 42, currentTime, 87.93f, 89.06f, offset, Mat, "000010001");
        checkMove(requiredMove);
        #endregion

        #region 43
        requiredMove = Move.Moves(currentMove, 43, currentTime, 89.06f, 90.56f, offset, Mat, "001010000");
        checkMove(requiredMove);
        #endregion

        #region 44
        requiredMove = Move.Moves(currentMove, 44, currentTime, 90.56f, 92.43f, offset, Mat, "100010000");
        checkMove(requiredMove);
        #endregion

        #region 45
        requiredMove = Move.Moves(currentMove, 45, currentTime, 92.43f, 93.73f, offset, Mat, "000110000");
        checkMove(requiredMove);
        #endregion

        #region 46
        requiredMove = Move.Moves(currentMove, 46, currentTime, 93.73f, 94.86f, offset, Mat, "000101000");
        checkMove(requiredMove);
        #endregion

        #region 47
        requiredMove = Move.Moves(currentMove, 47, currentTime, 94.86f, 96.23f, offset, Mat, "000011000");
        checkMove(requiredMove);
        #endregion

        #region 48
        requiredMove = Move.Moves(currentMove, 48, currentTime, 96.23f, 97.60f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 49
        requiredMove = Move.Moves(currentMove, 49, currentTime, 97.60f, 99.50f, offset, Mat, "010000000");
        checkMove(requiredMove);
        #endregion

        #region 50
        requiredMove = Move.Moves(currentMove, 50, currentTime, 99.50f, 100.53f, offset, Mat, "000010000");
        checkMove(requiredMove);
        #endregion

        #region 51
        requiredMove = Move.Moves(currentMove, 51, currentTime, 100.53f, 102.43f, offset, Mat, "000000010");
        checkMove(requiredMove);
        #endregion

        #region 52
        requiredMove = Move.Moves(currentMove, 52, currentTime, 102.43f, 103.83f, offset, Mat, "000101000");
        checkMove(requiredMove);
        #endregion

        #region 53
        requiredMove = Move.Moves(currentMove, 53, currentTime, 103.83f, 106.83f, offset, Mat, "0000010000");
        checkMove(requiredMove);
        #endregion

        //close connection after final move and destroy this script
        if (currentMove == numberOfMoves && endedConnection == false)
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


