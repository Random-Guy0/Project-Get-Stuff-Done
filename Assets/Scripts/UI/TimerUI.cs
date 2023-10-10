using System;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        float currentTime = PomodoroTimer.Instance.CurrentTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        _text.SetText(time.ToString("mm':'ss"));
    }
}