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
        Assert.AreEqual(statsCaptureTarget.CapturedStats.Score, statsCapture.CapturedStats.Score);
        Assert.AreEqual(statsCaptureTarget.CapturedStats.ObjectsCollected, statsCapture.CapturedStats.ObjectsCollected);
        Assert.AreEqual(Mathf.Round(statsCaptureTarget.CapturedStats.SessionDuration), Mathf.Round(statsCapture.CapturedStats.SessionDuration));
    }
}
