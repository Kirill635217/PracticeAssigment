using System;
using UnityEngine;

[Serializable]
public class Stats
{
    private float sessionDuration;
    private int score;
    private int objectsCollected;

    public float SessionDuration
    {
        get => sessionDuration;
        set => sessionDuration = value;
    }

    public int Score { get => score; set => score = value; }

    public int ObjectsCollected { get => objectsCollected; set => objectsCollected = value; }

    public void Initialize(int sessionDuration, int score, int objectsCollected)
    {
        this.sessionDuration = sessionDuration;
        this.score = score;
        this.objectsCollected = objectsCollected;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        try
        {
            var stats = (Stats)obj;
            return stats.Score == Score && Math.Abs(stats.SessionDuration - SessionDuration) < .5f &&
                   stats.ObjectsCollected == ObjectsCollected;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return false;
        }
    }
}