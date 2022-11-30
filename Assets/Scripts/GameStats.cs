using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : StatsCapture
{
    public static GameStats Instance;
    public int TimeOfLastCollectable { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public override void ObjectCollected()
    {
        base.ObjectCollected();
        TimeOfLastCollectable = (int)CapturedStats.SessionDuration;
    }

    private void Start()
    {
        StartCapture();
    }
}
