using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : StatsCapture
{
    public static GameStats Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCapture();
    }
}
