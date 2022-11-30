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
        const string target = @"{""SessionDuration"":1.0,""Score"":-2,""ObjectsCollected"":2}";
        Debug.Log(statsConverter.ConvertToJson(statsCapture.CapturedStats));
        Assert.AreEqual(target, statsConverter.ConvertToJson(statsCapture.CapturedStats));
    }
    
    [Test]
    public void ConvertFromJsonTest()
    {
        var statsCaptureTarget = new GameObject().AddComponent<GameStats>();
        var statsConverter = new StatsConverter();
        statsCaptureTarget.Initialize(1, -2, 2);
        const string json = @"{""SessionDuration"":1.0,""Score"":-2,""ObjectsCollected"":2}";
        Assert.AreEqual(true, statsCaptureTarget.CapturedStats.Equals(statsConverter.ConvertFromJson(json)));
    }
}
