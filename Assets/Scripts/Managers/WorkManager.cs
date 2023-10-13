using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityRawInput;

public class WorkManager : MonoBehaviour
{
    [SerializeField] private float checkPeriod = 1f;

    private float _timer;

    private bool _inputDetectedInPeriod = false;

    private int _secondsInFocus = 0;
    private int _secondsOfInput = 0;

    private void Start()
    {
        RawInput.Start();
        RawInput.WorkInBackground = true;
    }

    private void OnDestroy()
    {
        RawInput.Stop();
    }

    private void Update()
    {
        if (!_inputDetectedInPeriod)
        {
            _inputDetectedInPeriod = CheckForInput();
        }

        _timer += Time.deltaTime;
        if (_timer >= checkPeriod)
        {
            CheckForWork();
            _timer = 0f;
        }
        
        Debug.Log("Seconds in Focus: " + _secondsInFocus);
        Debug.Log("Seconds of Input: " + _secondsOfInput);
    }

    private void CheckForWork()
    {
        if (FocusedWindowIsWork())
        {
            _secondsInFocus++;
            
            if (_inputDetectedInPeriod)
            {
                _secondsOfInput++;
            }
        }
    }

    private bool CheckForInput()
    {
        return RawInput.AnyKeyDown;
    }

    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    private static extern int GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    private bool FocusedWindowIsWork()
    {
        var hwnd = GetForegroundWindow();
        if (hwnd == null) return false;

        GetWindowThreadProcessId(hwnd, out var processId);

        var result = false;

        foreach (var p in GameManager.Instance.Processes)
            if (p.Id == processId)
            {
                result = true;
                break;
            }

        return result;
    }
}