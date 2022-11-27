using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public abstract class CharacterMovement : MonoBehaviour
{
    public readonly int Speed = 3;
    
    private Vector3 direction;

    public void Move(Vector3 directionToMove)
    {
        direction = directionToMove;
        Debug.Log(direction);
        Move();
    }
    public void Move(float x, float y, float z)
    {
        direction.x = x;
        direction.y = y;
        direction.z = z;
        Move();
    }

    void Move()
    {
        transform.Translate(direction * Speed * Time.fixedDeltaTime);
    }
    
}
