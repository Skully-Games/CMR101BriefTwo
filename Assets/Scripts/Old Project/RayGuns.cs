using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayGuns : MonoBehaviour
{
    public Transform barrel;
    public float rayDist;
    public LayerMask lMask;
    public bool isGrow;
    public bool isShrink;

    public InputActionReference fireRay = null;
    public InputActionReference modeToggle = null;

    void Awake()
    {
        fireRay.action.started += Fire;
        modeToggle.action.started += Toggle;
        isGrow = true;
        isShrink = false;
    }

    void OnDestroy()
    {
        fireRay.action.started -= Fire;
        modeToggle.action.started -= Toggle;
    }

    private void Fire(InputAction.CallbackContext context)
    {
        if(isGrow == true)
        {
            Grow();
        }
        else 
        if(isShrink == true)
        {
            Shrink();
        }
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        isGrow = !isGrow;
        isShrink = !isShrink;
    }

    public void Grow()
    {
        RaycastHit hit;
        if (Physics.Raycast(barrel.transform.position, barrel.transform.forward, out hit, rayDist, lMask))
        {
            hit.collider.GetComponent<GrowthAndShrink>().GrowObjectAnIncrement();
        }
    }

    public void Shrink()
    {
        RaycastHit hit;
        if (Physics.Raycast(barrel.transform.position, barrel.transform.forward, out hit, rayDist, lMask))
        {
            hit.collider.GetComponent<GrowthAndShrink>().ShrinkObjectAnIncrement();
        }
    }
}
