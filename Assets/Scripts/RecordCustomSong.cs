using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RecordCustomSong : MonoBehaviour
{
    private MatInputController Mat = new MatInputController();

    public string csvName = "test.csv";
    public string song { get; set; }

    List<CustomMove> moves = new List<CustomMove>();

    // Start is called before the first frame update
    void Start()
    {
        csvName = "Dance-" + song;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void WriteCsv()
    {
        StreamWriter writer = new StreamWriter(@"songScripts\" + csvName);

        writer.WriteLine(song + ";;"); //First line = songname

        foreach (var move in moves)
        {
            writer.WriteLine(move.beginTime + ";" + move.endTime + ";" + move.move); // moves
        }

        writer.Close();
    }
}
