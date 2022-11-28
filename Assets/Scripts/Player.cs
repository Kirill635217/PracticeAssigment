using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterMovement
{
    [SerializeField] private GameObject model;
    
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var collectable = collision.gameObject.GetComponent<ICollectable>();
        if(collectable != null)
            GameManager.Instance.CollectObject(collectable);
    }

    private void Update()
    {
        SetMoveDirection(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
