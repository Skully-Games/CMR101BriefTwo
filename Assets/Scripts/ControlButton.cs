using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlButton : MonoBehaviour
{
    //Variables
    [Header("Move Buttons")]
    public bool upButton; 
    public bool downButton; 
    public bool leftButton; 
    public bool rightButton;
    [Header("Scale Buttons")]
    public bool scaleUpButton; 
    public bool scaleDownButton;
    [Header("Misc. Buttons")]
    public bool resetButton;
    public bool cycleButton;

    //References
    [Header("References")]
    public RemoteTransformControls RCT;
    
    public TextMeshProUGUI debugUI, moveUI, rotateUI, scaleUI, resetUI;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Controller")
        {
            if (resetButton)
            {
                RCT.ResetTargetObject();
            }
            if (cycleButton)
            {
                RCT.CycleTargetItem();
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Controller")
        {
            if (upButton)
            {
                RCT.MoveTargetForward();
            }
            if (downButton)
            {
                RCT.MoveTargetBackward();
            }
            if (leftButton)
            {
                RCT.MoveTargetLeft();
            }
            if (rightButton)
            {
                RCT.MoveTargetRight();
            }
            if (scaleUpButton)
            {
                RCT.RescaleTargetBigger();
            }
            if (scaleDownButton)
            {
                RCT.RescaleTargetSmaller();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        RCT.isOperating = false;
    }

}
