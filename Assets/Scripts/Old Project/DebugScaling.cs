using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScaling : MonoBehaviour
{
    public Camera cam;
    public float rayDist;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        
        Debug.DrawRay(ray.origin, ray.direction * rayDist, Color.red);
        if (Input.GetMouseButton(0))
        {
            RaycastHit hitLeft;
            if(Physics.Raycast(ray, out hitLeft, rayDist, layerMask))
            {
                Debug.Log("Left-clicked " + hitLeft.collider.name);
                hitLeft.collider.GetComponent<GrowthAndShrink>().GrowObjectAnIncrement();
            }
        }
        if (Input.GetMouseButton(1))
        {
            RaycastHit hitRight;
            if(Physics.Raycast(ray, out hitRight, rayDist, layerMask))
            {
                Debug.Log("Right-clicked " + hitRight.collider.name);
                hitRight.collider.GetComponent<GrowthAndShrink>().ShrinkObjectAnIncrement();
            }
        }
    }
}
