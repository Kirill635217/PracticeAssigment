using NUnit.Framework;
using UnityEngine;

public class StatsConverterTests
{
    [Test]
    public void ConvertToJsonTest()
    {
        var statsCapture = new GameObject().AddComponent<GameStats>();
        var statsConverter = new StatsConverter();
        statsCapture.Initialize(1, -2, 2);
        var target = @"{""SessionDuration"":1.0,""Score"":-2,""ObjectsCollected"":2}";
        Debug.Log(statsConverter.ConvertToJason(statsCapture.CapturedStats));
        Assert.AreEqual(target, statsConverter.ConvertToJason(statsCapture.CapturedStats));
    }
}
