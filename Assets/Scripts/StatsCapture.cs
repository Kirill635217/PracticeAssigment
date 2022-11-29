using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatsCapture : MonoBehaviour
{
    [Serializable]
    public struct Stats : IStats
    {
        public float SessionDuration { get; set; }
        public int Score { get; set; }
        public int ObjectsCollected { get; set; }
    }

    private Stats capturedStats;
    public Stats CapturedStats => capturedStats;
    private bool isCapturing;

    public virtual void StartCapture()
    {
        isCapturing = true;
    }

    public virtual void Initialize(int sessionDuration, int score, int objectsCollected)
    {
        capturedStats.SessionDuration = sessionDuration;
        capturedStats.Score = score;
        capturedStats.ObjectsCollected = objectsCollected;
    }

    public void ObjectCollected() => capturedStats.ObjectsCollected++;
    
    void Update()
    {
        if (!isCapturing) return;
        capturedStats.SessionDuration += Time.deltaTime;
        capturedStats.Score = GameManager.Instance.Points;
    }
}
