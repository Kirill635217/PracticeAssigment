using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameManagerTests
{
    [Test]
    public void MoveToNextLevel()
    {
        var gameManager = new GameObject().AddComponent<GameManager>();
        var startingLevel = gameManager.GetCurrentLevel();
        var pointsToNextLevel = gameManager.GetPointsToNextLevel();
        var collectable = new GameObject().AddComponent<Collectable>();
        collectable.Initialize(new List<int>
        {
            pointsToNextLevel
        }, ICollectable.Types.Capsule);
        gameManager.CollectObject(collectable);
        Assert.AreEqual(startingLevel + 1, gameManager.GetCurrentLevel());
    }
    
    [Test]
    public void CollectSameType()
    {
        var gameManager = new GameObject().AddComponent<GameManager>();
        var collectable = new GameObject().AddComponent<Collectable>();
        collectable.Initialize(new List<int>
        {
            2
        }, ICollectable.Types.Capsule);
        gameManager.CollectObject(collectable);
        gameManager.CollectObject(collectable);
        Assert.AreEqual(-2, gameManager.Points);
    }

}
