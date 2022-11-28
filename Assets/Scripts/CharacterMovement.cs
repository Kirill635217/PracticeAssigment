using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public abstract class CharacterMovement : MonoBehaviour
{
    public readonly int Speed = 1;
    
    private Vector3 direction;

    public void SetMoveDirection(Vector3 directionToMove)
    {
        direction = directionToMove;
        Move();
    }
    public void SetMoveDirection(float x, float y, float z)
    {
        direction.x = x;
        direction.y = y;
        direction.z = z;
        Move();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        direction = Vector3.ClampMagnitude(direction, 1);
        transform.Translate(direction * Speed * Time.fixedDeltaTime);
    }
    
}
