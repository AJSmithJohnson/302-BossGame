﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform viewTarget;
    public Vector3 offset;

    public float dampenAmount = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (viewTarget == null) return;
        transform.position = AnimMath.Dampen(transform.position, viewTarget.position + offset, dampenAmount);
    }
}
