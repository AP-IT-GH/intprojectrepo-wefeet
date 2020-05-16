using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class playCustomSong : MonoBehaviour
{
    protected MatInputController Mat = new MatInputController();
    private int currentMove = 0;
    private int score = 0;

    [Tooltip(@"the csv files should be located in intprojectrepo-wefeet\songScripts ")] ///-----TODO-----
    public string csvName = "test.csv";

    [Header("Add the 9 floor tiles")]
    [Tooltip("start by the top left tile, then the one to the right and so on, then move down a row")]
    public GameObject[] tiles;

    [Header("Add the 9 screen tiles")]
    [Tooltip("start by the top left tile, then the one to the right and so on, then move down a row")]
    public GameObject[] screenTiles;

    public int Score { get => score; }

    [Header("Changing lights")]
    [Tooltip("these light change color and give feedback with a good or bad move")]
    public List<Light> lights;
    private float timer = float.MaxValue;

    private bool endedConnection = false;
    private float startTime;
    bool begin = false;
    int numberOfMoves;

    public string song { get; private set; }

    public string currentMoveString = "000000000";


    List<CustomMove> moves = new List<CustomMove>();

    // Start is called before the first frame update
    void Start()
    {
        //read in text file
        StreamReader reader = new StreamReader(@"songScripts\" + csvName);
        //get song name
        song = reader.ReadLine().Trim(';');
        //add moves
        while (!reader.EndOfStream)
        {
            string data = reader.ReadLine();
            var split = data.Split(';');

            moves.Add(new CustomMove(float.Parse(split[0]), float.Parse(split[1]), split[2]));
        }
        reader.Close();

        //count nr of moves
        numberOfMoves = moves.Count();
        Debug.Log(song);
        Debug.Log("nr of moves: " + numberOfMoves);

        //setup mat and scene
        //Mat.Start();
        score = 0;
        currentMove = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Mat.Update();

        if (!begin)
        {
            startTime = Time.time;
            begin = true;
        }

        float currentTime = Time.time - startTime;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            changeLight(Color.white, float.MaxValue);
        }
        ShowFeet();
        ShowMove();

        int movenr = 0;
        foreach (CustomMove move in moves)
        {
            MoveAction(move.CheckMove(currentMove, currentTime, Mat, movenr, this));
            movenr++;
        }


        //close connection after final move and destroy this script
        if (currentMove == numberOfMoves && endedConnection == false)
        {
            Mat.CloseConnection();
            endedConnection = true;

            changeLight(Color.white, float.MaxValue);
            currentMoveString = "000000000";
            ShowMove();
            Destroy(this);
        }
    }

    private void ShowMove() //visually show where your feet are
    {
        for (int i = 0; i < screenTiles.Length; i++)
        {
            screenTiles[i].SetActive(false);
        }
        
        if (currentMoveString[0] == '1') screenTiles[0].SetActive(true);
        if (currentMoveString[1] == '1') screenTiles[1].SetActive(true);
        if (currentMoveString[2] == '1') screenTiles[2].SetActive(true);
        if (currentMoveString[3] == '1') screenTiles[3].SetActive(true);
        if (currentMoveString[4] == '1') screenTiles[4].SetActive(true);
        if (currentMoveString[5] == '1') screenTiles[5].SetActive(true);
        if (currentMoveString[6] == '1') screenTiles[6].SetActive(true);
        if (currentMoveString[7] == '1') screenTiles[7].SetActive(true);
        if (currentMoveString[8] == '1') screenTiles[8].SetActive(true);
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
    private void MoveAction(CustomMove.moveResponse requiredMove)
    {
        switch (requiredMove)
        {
            case CustomMove.moveResponse.Correct:
                CorrectMove();
                break;
            case CustomMove.moveResponse.Incorrect:
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

public class CustomMove
{ 
    public enum moveResponse
    {
        Correct,
        Incorrect,
        Waiting
    }


    public float beginTime { get; private set; }
    public float endTime { get; private set; }
    public string move { get; private set; }


    public CustomMove(float BeginTime, float EndTime, string Move)
    {
        this.beginTime = BeginTime;
        this.endTime = EndTime;
        this.move = Move;
    }

    public moveResponse CheckMove(int currentMove, float currentTime, MatInputController Mat, int moveNumber, playCustomSong baseClass)
    {
        if (currentTime > beginTime && currentTime < endTime)
        {
            if (currentMove == moveNumber)
            {
                baseClass.currentMoveString = this.move;

                List<bool> moves = new List<bool>();
                foreach (char item in move)
                {
                    if (item == '0')
                    {
                        moves.Add(false);
                    }
                    else if (item == '1')
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
