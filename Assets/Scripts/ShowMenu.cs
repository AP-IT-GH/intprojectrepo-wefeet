using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ShowMenu : MonoBehaviour
{
    public bool activate = true;

    // a reference to the action
    public SteamVR_Action_Boolean MenuOnOff;
    // a reference to the hand
    public SteamVR_Input_Sources handType;

    // Start is called before the first frame update
    void Start()
    {
        MenuOnOff.AddOnStateDownListener(TriggerDown, handType);
        MenuOnOff.AddOnStateUpListener(TriggerUp, handType);
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("up");
        GameObject.FindWithTag("mainMenuTag").SetActive(true);
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("down");
        GameObject.FindWithTag("mainMenuTag").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.FindWithTag("mainMenuTag").SetActive(activate);
        MenuOnOff.AddOnStateDownListener(TriggerDown, handType);
        MenuOnOff.AddOnStateUpListener(TriggerUp, handType);
    }
}
