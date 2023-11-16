using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private TMP_Text _scoreText;

    private void Start()
    {
        _scoreText = GetComponent<TMP_Text>();
        SetScoreText(BattleManager.Instance.Score);
        BattleManager.Instance.OnScoreChanged += SetScoreText;
    }

    void SetScoreText(int score)
    {
        _scoreText.SetText("Score: {0}", score);
    }
}
