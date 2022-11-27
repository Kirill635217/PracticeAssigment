using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTests
{
    [UnityTest]
    public IEnumerator MoveForward()
    {
        var player = new GameObject().AddComponent<Player>();
        player.Move(Vector3.forward);
        yield return new WaitForSeconds(Time.fixedDeltaTime);
        Assert.AreEqual(new Vector3(0, 0, player.Speed * Time.fixedDeltaTime), player.transform.position);
    }

    [UnityTest]
    public IEnumerator MoveBackward()
    {
        var player = new GameObject().AddComponent<Player>();
        player.Move(Vector3.back);
        yield return new WaitForSeconds(Time.fixedDeltaTime);
        Assert.AreEqual(new Vector3(0, 0, -player.Speed * Time.fixedDeltaTime), player.transform.position);
    }

    [UnityTest]
    public IEnumerator MoveLeft()
    {
        var player = new GameObject().AddComponent<Player>();
        player.Move(Vector3.left);
        yield return new WaitForSeconds(Time.fixedDeltaTime);
        Assert.AreEqual(new Vector3(-player.Speed * Time.fixedDeltaTime, 0, 0), player.transform.position);
    }

    [UnityTest]
    public IEnumerator MoveRight()
    {
        var player = new GameObject().AddComponent<Player>();
        player.Move(Vector3.right);
        yield return new WaitForSeconds(Time.fixedDeltaTime);
        Assert.AreEqual(new Vector3(player.Speed * Time.fixedDeltaTime, 0, 0), player.transform.position);
    }
}