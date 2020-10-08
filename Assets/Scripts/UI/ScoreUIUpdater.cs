using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIUpdater : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI _textScore;
    private void OnEnable()
    {
        player.scoreUpdated += UpdateScore;
    }
    
    private void OnDisable()
    {
        player.scoreUpdated -= UpdateScore;
    }

    private void UpdateScore(int score)
    {
        _textScore.text = score.ToString();
    }
}
