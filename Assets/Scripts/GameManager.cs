using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    readonly int[] PointsToNextLevel = new[]
    {
        100, 100, 400
    };

    private int currentLevel = 1;
    private int points;

    private ICollectable.Types previousCollectableType = ICollectable.Types.None;

    public int Points => points;

    private IStatsConverter statsConverter;
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    void CheckPoints()
    {
        if (points < PointsToNextLevel[Mathf.Clamp(currentLevel - 1, 0, PointsToNextLevel.Length - 1)]) return;
        if (currentLevel - 1 < PointsToNextLevel.Length - 1)
        {
            points = 0;
            currentLevel++;
        }
        else
            StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        statsConverter ??= new StatsConverter();
        if(GameStats.Instance != null)
            SaveManager.SaveAsTextFile(Application.streamingAssetsPath, "GameStats", statsConverter.ConvertToJson(GameStats.Instance.CapturedStats));
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Main");
    }

    public void CollectObject(ICollectable collectable)
    {
        if (previousCollectableType != collectable.Type)
            points += collectable.Value[Mathf.Clamp(currentLevel - 1, 0, collectable.Value.Count - 1)];
        else
            points -= (collectable.Value[Mathf.Clamp(currentLevel - 1, 0, collectable.Value.Count - 1)] * 2);

        CheckPoints();
        previousCollectableType = collectable.Type;
        collectable.Collected();
        if (GameStats.Instance != null)
            GameStats.Instance.ObjectCollected();
        if (SpawnManager.Instance != null)
            SpawnManager.Instance.SpawnObject();
    }

    public int GetCurrentLevel() => currentLevel;

    public int GetPointsToNextLevel() =>
        PointsToNextLevel[Mathf.Clamp(currentLevel - 1, 0, PointsToNextLevel.Length - 1)];
}