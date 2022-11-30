using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterMovement
{
    [SerializeField] private GameObject model;
    private Vector3 previousPosition = new Vector3(0, .5f, 0);

    void Start()
    {
        StartCoroutine(CheckPosition());
    }

    private void OnTriggerEnter(Collider other)
    {
        var collectable = other.GetComponent<ICollectable>();
        if (collectable != null)
            GameManager.Instance.CollectObject(collectable);
    }

    IEnumerator CheckPosition()
    {
        yield return new WaitForSeconds(1);
        if (!(Vector3.Distance(previousPosition, transform.position) < 1f))
        {
            previousPosition = transform.position;
            StartCoroutine(CheckPosition());
            yield break;
        }
        var isStuck = CheckForCubes();
        if (isStuck)
            GameManager.Instance.PlayerStuck();
        else
        {
            previousPosition = transform.position;
            StartCoroutine(CheckPosition());
        }
    }

    bool CheckForCubes()
    {
        var colliders = Physics.OverlapSphere(transform.position, 1f);
        var cubes = 0;
        foreach (var collider in colliders)
        {
            if (collider.gameObject.layer == 3)
                cubes++;
            if (cubes > 4)
                return true;
        }
        return false;
    }

    private void Update()
    {
        // SetMoveDirection(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}