using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Valve.VR;

public class RecordCustomSong : MonoBehaviour
{
    // MAT
    private MatInputController Mat = new MatInputController();

    // CSV
    private string csvName = "test.csv";
    public string song { get; set; }

    // Moves
    List<CustomMove> moves = new List<CustomMove>();
    public int maxMoves = 10;

    // UI Input    
    public SteamVR_Action_Boolean RecordTrigger;    
    public SteamVR_Input_Sources handType;
    private bool TriggerOnOff = false;

    // Timings
    private float prevTime = 0f;
    private float currTime = 0f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Start Mat & Timer
        Mat.Start();
        timer = 0f;
        // INPUT
        RecordTrigger.AddOnStateDownListener(TriggerDown, handType);
        RecordTrigger.AddOnStateUpListener(TriggerUp, handType);
    }

    // Update is called once per frame
    void Update()
    {
        // Update Mat & Timer
        Mat.Update();
        timer += Time.deltaTime;
        // INPUT
        RecordTrigger.AddOnStateDownListener(TriggerDown, handType);
        RecordTrigger.AddOnStateUpListener(TriggerUp, handType);
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (TriggerOnOff)
            TriggerOnOff = false;
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {        
        if (!TriggerOnOff && maxMoves <10)
        {
            TriggerOnOff = true;
            //  Add new move
            currTime = timer;
            moves.Add(new CustomMove(prevTime, currTime, LookAtMove()));
            prevTime = currTime;
            maxMoves++;
        }        
        else
        {
            WriteCsv();
        }
    }

    private string LookAtMove()
    {
        string move = "";

        List<bool> tiles = new List<bool>();

        tiles[0] = Mat.LeftForward;
        tiles[1] = Mat.Forward;
        tiles[2] = Mat.RightForward;
        tiles[3] = Mat.Left;
        tiles[4] = Mat.Center;
        tiles[5] = Mat.Right;
        tiles[6] = Mat.LeftBackward;
        tiles[7] = Mat.Backward;
        tiles[8] = Mat.RightBackward;

        foreach (var state in tiles)
        {
            if (state == true)
                move += "1";
            else
                move += "0";
        }

        return move;
    }

    private void WriteCsv()
    {
        csvName = "Dance-" + song;

        StreamWriter writer = new StreamWriter(@"songScripts\" + csvName + ".csv");

        writer.WriteLine(song + ";;"); //First line = songname

        foreach (var move in moves)
        {
            writer.WriteLine(move.beginTime + ";" + move.endTime + ";" + move.move); // moves
        }

        writer.Close();

        Destroy(this);
    }
}
