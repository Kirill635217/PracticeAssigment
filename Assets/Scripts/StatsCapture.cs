using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatsCapture : MonoBehaviour
{
    private Stats capturedStats;
    public Stats CapturedStats => capturedStats;
    private bool isCapturing;

    public void StartCapture()
    {
        capturedStats ??= new Stats();
        isCapturing = true;
    }

    public void Initialize(int sessionDuration, int score, int objectsCollected)
    {
        capturedStats ??= new Stats();
        capturedStats.Initialize(sessionDuration, score, objectsCollected);
    }

    public virtual void ObjectCollected() => capturedStats.ObjectsCollected++;
    
    void Update()
    {
        if (!isCapturing) return;
        capturedStats.SessionDuration += Time.deltaTime;
        capturedStats.Score = GameManager.Instance.Points;
    }
}
