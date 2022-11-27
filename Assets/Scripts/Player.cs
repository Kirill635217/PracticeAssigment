using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterMovement
{
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Move(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
