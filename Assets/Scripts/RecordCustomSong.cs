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
    public string csvName = "test.csv";
    public string song { get; set; }

    // Moves
    List<CustomMove> moves = new List<CustomMove>();

    // UI Input    
    public SteamVR_Action_Boolean RecordTrigger;    
    public SteamVR_Input_Sources handType;
    private bool TriggerOnOff = false;

    // Timings
    private float prevTime = 0;
    private float currTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        RecordTrigger.AddOnStateDownListener(TriggerDown, handType);
        RecordTrigger.AddOnStateUpListener(TriggerUp, handType);
    }

    // Update is called once per frame
    void Update()
    {
        RecordTrigger.AddOnStateDownListener(TriggerDown, handType);
        RecordTrigger.AddOnStateUpListener(TriggerUp, handType);
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //selectedGameObject.SetActive(false);
        if (TriggerOnOff)
            TriggerOnOff = false;
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //selectedGameObject.SetActive(true);
        //Debug.Log("change menu");
        if (!TriggerOnOff)
        {
            TriggerOnOff = true;
            //  Add new move
            moves.Add(new CustomMove(prevTime, currTime, "000000000")); // TODO: Change by input mat
        }
    }

    private void WriteCsv()
    {
        csvName = "Dance-" + song;

        StreamWriter writer = new StreamWriter(@"songScripts\" + csvName);

        writer.WriteLine(song + ";;"); //First line = songname

        foreach (var move in moves)
        {
            writer.WriteLine(move.beginTime + ";" + move.endTime + ";" + move.move); // moves
        }

        writer.Close();
    }
}
