using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ShowMenu : MonoBehaviour
{
    // a reference to the action
    public SteamVR_Action_Boolean MenuOnOff;
    // a reference to the hand
    public SteamVR_Input_Sources handType;
    //the gameObject
    public GameObject selectedGameObject;
    
    // Start is called before the first frame update
    void Start()
    {
        MenuOnOff.AddOnStateDownListener(TriggerDown, handType);
        MenuOnOff.AddOnStateUpListener(TriggerUp, handType);
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //GameObject.FindWithTag("mainMenuTag").SetActive(true); //werkt niet
        selectedGameObject.SetActive(false);
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //GameObject.FindWithTag("mainMenuTag").SetActive(false);
        selectedGameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {        
        MenuOnOff.AddOnStateDownListener(TriggerDown, handType);
        MenuOnOff.AddOnStateUpListener(TriggerUp, handType);
    }
}
