using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemoteTransformControls : MonoBehaviour
{
    public GameObject targetController;

    public GameObject[] maleableObjs;
    public int indx;

    #region Handles
    // the handles starting Transform information (for comparison with moved position, as well as to reset it)
    private Vector3 handleDefaultPosition;
    private Vector3 handleStartingPosition;

    // the boolean (true or false) indication about what this handle is manipulating: movement, rotation and/or scale
    // Note: if all three are on would be confusing, as position and scale would change simultaneously
    public bool movementHandle = true;
    public bool rotateHandle = false;
    public bool scaleHandle = false;

    public bool isOperating = false;
    #endregion

    // The multiplier (i.e. sensitivity) of the handle, i.e. how much more/less does the target move compared to the handle
    public float moveMultiplier = 1f;
    public float scaleMultiplier = 1f;

    public float scaleOffset = -.5f;
    public float minScale = .1f;
    public float maxScale = 2f;

    // What gameobject is the handle manipulating?
    public GameObject targetObject = null;

    // The handle's starting transform (to reset it)
    private Vector3 targetStartPosition;

    public TextMeshProUGUI targetUI;

    //public TextMeshProUGUI debugUI;
    //public TextMeshProUGUI moveUI;
    //public TextMeshProUGUI rotateUI;
    //public TextMeshProUGUI scaleUI;
    //public TextMeshProUGUI resetUI;

    private void Start()
    {
        ResetUIText();

        // Set up handle's values if you use one
        //InitialiseHandle();

        maleableObjs = GameObject.FindGameObjectsWithTag("Transformable");
    }

    private void ResetUIText()
    {
        //debugUI.text = "Debug: nothing to report!";
        //moveUI.text = "Not using yellow cube";
        //rotateUI.text = "Not using orange cube";
        //scaleUI.text = "Not using red cube";
        //resetUI.text = "Not using black cube";
    }
    #region Grip-based Methods
    //// GRIP-BASED METHODS FOR TRANSFORM MANIPULATION

    //private void InitialiseHandle()
    //{
    //    // Store the handle's starting position 
    //    handleDefaultPosition = transform.position;
    //    handleStartingPosition = transform.position;

    //    // Store the target's starting position in case we wish to reset it
    //    targetStartPosition = targetObject.transform.position;
    //}

    ////private void Update()
    ////{
    ////    // skip this update if this handle is not in operation 
    ////    if (!isOperating) return;

    ////    // ...otherwise check for manipulation
    ////    if (movementHandle)
    ////    {
    ////        debugUI.text = "Moving target!";
    ////        MoveTarget();
    ////    }
    ////    if (rotateHandle)
    ////    {
    ////        debugUI.text = "Rotating target!";
    ////        RotateTarget();
    ////    }
    ////    if (scaleHandle)
    ////    {
    ////        debugUI.text = "Rescaling target!";
    ////        ScaleTarget();
    ////    }
    ////}

    //// Calculates the target's new position as offset from the handle's starting position (x,y,z axes)
    //private void MoveTarget()
    //{
    //    // if the cube is left or right of start position, move target at move speed
    //    if (transform.position.x < handleStartingPosition.x)
    //    {
    //        targetObject.transform.Translate(-moveMultiplier * Time.deltaTime, 0, 0);
    //    }
    //    else if (transform.position.x > handleStartingPosition.x)
    //    {
    //        targetObject.transform.Translate(moveMultiplier * Time.deltaTime, 0, 0);
    //    }

    //    // if the cube is forward or backward of start position, move target at move speed
    //    if (transform.position.z < handleStartingPosition.z)
    //    {
    //        targetObject.transform.Translate(0, 0, -moveMultiplier * Time.deltaTime);
    //    }
    //    else if (transform.position.z > handleStartingPosition.z)
    //    {
    //        targetObject.transform.Translate(0, 0, moveMultiplier * Time.deltaTime);
    //    }

    //    moveUI.text = "Yellow cube start pos: " + handleStartingPosition + " curr pos: " + transform.position;
    //}

    //// Calculates the target's new position by this object's rotation
    //private void RotateTarget()
    //{
    //    // change the target's rotation to the handle's rotation
    //    targetObject.transform.localRotation = transform.localRotation;
    //    rotateUI.text = "Brown rotate by cube angle: " + transform.localRotation;
    //}

    //// Calculates the target's new scale dynamically based on the handle's movement)
    //private void ScaleTarget()
    //{
    //    float distance;

    //    // scale to object height
    //    distance = (transform.position.y + scaleOffset) * scaleMultiplier;

    //    // make sure distance is clamped between min and max scale
    //    distance = Mathf.Clamp(distance, minScale, maxScale);

    //    // generalise scale to x, y and z from the distance value
    //    Vector3 newScale = new Vector3(distance, distance, distance);
    //    // set the cube's scale to the newScale
    //    targetObject.transform.localScale = newScale;
    //    scaleUI.text = "Red scale by cube y offset: " + distance;
    //}

    //// If you wish to reset the target to its starting position, rotation and size, call this method
    public void ResetTargetObject()
    {
        //resetUI.text = "Reset target with black cube!";
        targetObject.transform.position = targetStartPosition;
        targetObject.transform.rotation = new Quaternion();
        targetObject.transform.localScale = new Vector3(1f, 1f, 1f); //targetStartTransform.localScale;
    }

    //// Call this method to start moving the cube with the handle
    //public void ActivateHandle()
    //{
    //    // getting handle 'starting point' as where it is grabbed by controller
    //    handleStartingPosition = targetController.transform.position;

    //    debugUI.text = "Debug: Selected " + gameObject.name;
    //    isOperating = true;
    //}

    //// Call this method when a handle is released to reset the handle and its manipulation booleans
    //public void ReleaseHandle()
    //{
    //    debugUI.text = "Debug: Deselected " + gameObject.name;

    //    transform.position = handleDefaultPosition;
    //    transform.rotation = new Quaternion();

    //    isOperating = false;

    //    ResetUIText();
    //}
    #endregion

    //*********************************************************************************
    // BUTTON-BASED METHODS FOR TRANSFORM MANIPULATION

    private void Update()
    {
        targetObject = maleableObjs[indx];
        targetUI.text = targetObject.name;
    }

    public void MoveTargetLeft()
    {
        //debugUI.text = "Debug: moved left " + gameObject.name;
        targetObject.transform.Translate(-moveMultiplier * Time.deltaTime, 0, 0);
    }

    public void MoveTargetRight()
    {
        //debugUI.text = "Debug: moved right " + gameObject.name;
        targetObject.transform.Translate(moveMultiplier * Time.deltaTime, 0, 0);

    }

    public void MoveTargetForward()
    {
        //debugUI.text = "Debug: moved forward " + gameObject.name;
        targetObject.transform.Translate(0, 0, moveMultiplier * Time.deltaTime);

    }

    public void MoveTargetBackward()
    {
        //debugUI.text = "Debug: moved back " + gameObject.name;
        targetObject.transform.Translate(0, 0, -moveMultiplier * Time.deltaTime);
    }

    public void RotateTargetLeft()
    {
        //debugUI.text = "Debug: rotated left " + gameObject.name;
        targetObject.transform.Rotate(0, -moveMultiplier * Time.deltaTime, 0);

    }

    public void RotateTargetRight()
    {
        //debugUI.text = "Debug: rotated right " + gameObject.name;
        targetObject.transform.Rotate(0, moveMultiplier * Time.deltaTime, 0);
    }

    public void RescaleTargetBigger()
    {
        //debugUI.text = "Debug: made bigger " + gameObject.name;

        Vector3 newScale = new Vector3(targetObject.transform.localScale.x + scaleMultiplier * Time.deltaTime,
                                       targetObject.transform.localScale.y + scaleMultiplier * Time.deltaTime,
                                       targetObject.transform.localScale.z + scaleMultiplier * Time.deltaTime);

        targetObject.transform.localScale = newScale;

    }

    public void RescaleTargetSmaller()
    {
        //debugUI.text = "Debug: made smaller " + gameObject.name;

        Vector3 newScale = new Vector3(targetObject.transform.localScale.x - scaleMultiplier * Time.deltaTime,
                                       targetObject.transform.localScale.y - scaleMultiplier * Time.deltaTime,
                                       targetObject.transform.localScale.z - scaleMultiplier * Time.deltaTime);

        targetObject.transform.localScale = newScale;
    }

    public void CycleTargetItem()
    {
        Debug.Log("Previous target: " + maleableObjs[indx]); //Prints current value to console.
        if (indx >= maleableObjs.Length - 1)
        {
            indx = 0;
        }
        else
        {
            indx += 1;
            Debug.Log("Current target: " + maleableObjs[indx]);
        }
    }
}
