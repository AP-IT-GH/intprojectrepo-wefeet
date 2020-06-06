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

    private bool TriggerOnOff = false;
    private bool showMenuOnOff = true;
    
    // Start is called before the first frame update
    void Start()
    {
        MenuOnOff.AddOnStateDownListener(TriggerDown, handType);
        MenuOnOff.AddOnStateUpListener(TriggerUp, handType);
    }
    // Update is called once per frame
    void Update()
    {
        MenuOnOff.AddOnStateDownListener(TriggerDown, handType);
        MenuOnOff.AddOnStateUpListener(TriggerUp, handType);
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
            showMenuOnOff = !showMenuOnOff;
            ChangeMenu();
        }
    }    

    private void ChangeMenu()
    {        
        selectedGameObject.SetActive(showMenuOnOff);
    }
}
