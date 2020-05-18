using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class playCustomSong : MonoBehaviour
{
    private MatInputController Mat = new MatInputController();
    private int currentMove = 0;
    private int score = 0;

    [Tooltip(@"the csv files should be located in intprojectrepo-wefeet\songScripts ")] ///-----TODO-----
    public string csvName = "test.csv";

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
    bool begin = false;
    int numberOfMoves;

    public string song { get; private set; }


    List<CustomMove> moves = new List<CustomMove>();

    // Start is called before the first frame update
    void Start()
    {
        //setup mat and scene
        //Mat.Start();
        score = 0;
        currentMove = 0;

        //read in text file
        StreamReader reader = new StreamReader(@"songScripts\" + csvName);
        //get song name
        song = reader.ReadLine().Trim(';');
        //add moves
        while (!reader.EndOfStream)
        {
            string data = reader.ReadLine();
            var split = data.Split(';');

            Debug.Log(split[0]);

            moves.Add(new CustomMove(float.Parse(split[0]), float.Parse(split[1]), split[2]));
        }
        //count nr of moves
        numberOfMoves = moves.Count();
        Debug.Log(song);
        Debug.Log("nr of moves: " + numberOfMoves);
    }

    // Update is called once per frame
    void Update()
    {


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

    public moveResponse CheckMove()
    {
        return moveResponse.Correct;
    }
}
