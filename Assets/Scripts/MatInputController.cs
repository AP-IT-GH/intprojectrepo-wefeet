using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO.Ports;
using Microsoft.Win32;

//step1) reading serial input
//step2) using as a controller


public class MatInputController : MonoBehaviour
{
    string comport = null;
    private SerialPort port;
    bool arduinoConnected = false;
    string lastCompleteInput = "000000000,";

    public bool Forward { get; protected set; }
    public bool LeftForward { get; protected set; }
    public bool RightForward { get; protected set; }
    public bool Left { get; protected set; }
    public bool Center { get; protected set; }
    public bool Right { get; protected set; }
    public bool Backward { get; protected set; }
    public bool LeftBackward { get; protected set; }
    public bool RightBackward { get; protected set; }




    // Start is called before the first frame update
    public void Start()
    {
        Forward = false;
        LeftForward = false;
        RightForward = false;
        RightBackward = false;
        Left = false;
        Center = false;
        Right = false;
        Backward = false;
        LeftBackward = false;
        RightBackward = false;

        //detecting the port
        try
        {
            comport = AutodetectArduinoPort();

            //creating the reader
            if(comport != null)
            {
                arduinoConnected = true;
                Debug.Log("Arduino connected on port " + comport);

                OpenConnection();
            }
            else
            {
                Debug.Log("No arduino found");
            }
           
        }
        catch(Exception e)
        {
            Debug.Log("No arduino found: " + e);
        }
    }

    // Update is called once per frame
    public void Update()
    {
        //reading serial data if an arduino is connected
        if (arduinoConnected)
        {
            try
            {
                string myString = port.ReadLine();
                lastCompleteInput = myString;
                port.ReadTimeout = 25;
            }
            catch (Exception e)
            {
                //ignore
            }
        }
        Move();
    }



    public void Move()
    {
        //set all false
        Forward = false;
        LeftForward = false;
        RightForward = false;
        RightBackward = false;
        Left = false;
        Center = false;
        Right = false;
        Backward = false;
        LeftBackward = false;
        RightBackward = false;

        //set input true
        if (lastCompleteInput[0] == '1')
        {
            LeftForward = true;
        }
        if (lastCompleteInput[1] == '1')
        {
            Forward = true;
        }
        if (lastCompleteInput[2] == '1')
        {
            RightForward = true;
        }
        if (lastCompleteInput[3] == '1')
        {
            Left = true;
        }
        if (lastCompleteInput[4] == '1')
        {
            Center = true;
        }
        if (lastCompleteInput[5] == '1')
        {
            Right = true;
        }
        if (lastCompleteInput[6] == '1')
        {
            LeftBackward = true;
        }
        if (lastCompleteInput[7] == '1')
        {
            Backward = true;
        }
        if (lastCompleteInput[8] == '1')
        {
            RightBackward = true;
        }
    }



    public void OpenConnection()
    {
        port = new SerialPort(comport, 9600);
        if (port != null)
        {
            if (port.IsOpen)
            {
                port.Close();
                Debug.Log("Closing port, because it was already open!");
            }
            else
            {
                port.Open();
                Debug.Log("Port Opened!");
            }
        }
        else
        {
            Debug.Log("no port found");
        }
        Debug.Log("Opening connection finished running");
    }

    public void CloseConnection()
    {
        if (port != null && port.IsOpen)
        {
            port.Close();
            Debug.Log("Connection closed");
        }
    }

    void OnApplicationQuit()
    {
        if (port != null)
            port.Close();
    }


    //get comport with arduino connected
    private static string AutodetectArduinoPort()
    {
        List<string> comports = new List<string>();
        RegistryKey rk1 = Registry.LocalMachine;
        RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
        string temp;
        foreach (string s3 in rk2.GetSubKeyNames())
        {
            RegistryKey rk3 = rk2.OpenSubKey(s3);
            foreach (string s in rk3.GetSubKeyNames())
            {
                if (s.Contains("VID") && s.Contains("PID"))
                {
                    RegistryKey rk4 = rk3.OpenSubKey(s);
                    foreach (string s2 in rk4.GetSubKeyNames())
                    {
                        RegistryKey rk5 = rk4.OpenSubKey(s2);                        

                        if ((temp = (string)rk5.GetValue("FriendlyName")) != null && temp.Contains("USB Serial Port"))
                        {
                            RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                            if (rk6 != null && (temp = (string)rk6.GetValue("PortName")) != null)
                            {
                                comports.Add(temp);
                            }
                        }
                    }
                }
            }
        }

        if (comports.Count > 0)
        {
            foreach (string s in SerialPort.GetPortNames())
            {
                if (comports.Contains(s))
                    return s;
            }
        }
        else
        {
            Debug.Log("no connected devices found");
        }

        return null;
    }
}
