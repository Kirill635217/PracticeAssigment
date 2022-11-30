using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI sessionDurationText;
    [SerializeField] private TextMeshProUGUI levelText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        if (GameManager.Instance != null)
        {
            if(scoreText != null)
                scoreText.text = $"Score: {GameManager.Instance.Points}";
            if(levelText != null)
                levelText.text = $"Level: {GameManager.Instance.GetCurrentLevel()}";
        }

        if(GameStats.Instance != null && sessionDurationText != null)
            sessionDurationText.text = $"Duration: {Mathf.RoundToInt(GameStats.Instance.CapturedStats.SessionDuration)}";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }
}