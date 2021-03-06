﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    CharacterController pawn;
    public GroundPointAt groundPointAt;

    public Vector3 walkDir { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        pawn = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        print(h);
        Vector3 input = new Vector3(h, 0, v);
        if (input.sqrMagnitude > 1) input.Normalize();
        
        walkDir = input.x * groundPointAt.transform.right + input.z * groundPointAt.transform.forward;



        pawn.SimpleMove(walkDir * moveSpeed);
        
        
    }
}
