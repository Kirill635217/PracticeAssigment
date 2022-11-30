using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameStatsTests
{
    [UnityTest]
    public IEnumerator GameStatsTestsWithEnumeratorPasses()
    {
        var statsCapture = new GameObject().AddComponent<GameStats>();
        var gameManager = new GameObject().AddComponent<GameManager>();
        var collectable = new GameObject().AddComponent<Collectable>();
        collectable.Initialize(new List<int>
        {
            2
        }, ICollectable.Types.Capsule);
        statsCapture.StartCapture();
        gameManager.CollectObject(collectable);
        gameManager.CollectObject(collectable);
        yield return new WaitForSeconds(1);
        var statsCaptureTarget = new GameObject().AddComponent<GameStats>();
        statsCaptureTarget.Initialize(1, -2, 2);
        Assert.AreEqual(true, statsCaptureTarget.CapturedStats.Score.Equals(statsCapture.CapturedStats.Score));
    }
}