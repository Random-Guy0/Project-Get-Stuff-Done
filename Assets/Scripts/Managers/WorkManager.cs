using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityRawInput;

public class WorkManager : MonoBehaviour
{
    [SerializeField] private float checkPeriod = 1f;

    private float _timer;

    private bool _inputDetectedInPeriod = false;

    public int SecondsInFocus { get; private set; }
    public int SecondsOfInput { get; private set; }

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
        
        //Debug.Log("Seconds in Focus: " + SecondsInFocus);
        //Debug.Log("Seconds of Input: " + SecondsOfInput);
    }

    private void CheckForWork()
    {
        if (FocusedWindowIsWork())
        {
            SecondsInFocus++;
            
            if (_inputDetectedInPeriod)
            {
                SecondsOfInput++;
                _inputDetectedInPeriod = false;
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