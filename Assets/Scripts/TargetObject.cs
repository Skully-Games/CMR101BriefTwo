using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public Vector3 startPos, currPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currPos = transform.position;
    }
}
