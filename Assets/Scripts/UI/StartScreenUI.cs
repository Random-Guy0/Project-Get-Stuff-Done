using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenUI : MonoBehaviour
{
    public void StartGame()
    {
        PomodoroTimer.Instance.StartTimer();
    }
}
