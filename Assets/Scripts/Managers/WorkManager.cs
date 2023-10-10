using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class WorkManager : MonoBehaviour
{
    [SerializeField] private float checkPeriod = 1f;

    private float _timer = 0f;

    private bool inputDetectedInPeriod = false;

    private void Update()
    {
        CheckForInput();
        
        _timer += Time.deltaTime;
        if (_timer >= checkPeriod)
        {
            CheckForWork();
            _timer = 0f;
        }
    }

    private void CheckForWork()
    {
        Debug.Log("Chosen Applications in focus: "+ FocusedWindowIsWork());
    }

    private void CheckForInput()
    {
        //Keyboard keyboard = Keyboard.current;
        //Mouse mouse = Mouse.current;
        //Debug.Log(keyboard.anyKey.isPressed);
        //if(keyboard.anyKey.isPressed || mouse.delta.magnitude > 0f)
    }

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();
    
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    private bool FocusedWindowIsWork()
    {
        IntPtr hwnd = GetForegroundWindow();
        if (hwnd == null)
        {
            return false;
        }

        GetWindowThreadProcessId(hwnd, out uint processId);

        bool result = false;

        foreach (Process p in GameManager.Instance.Processes)
        {
            if (p.Id == processId)
            {
                result = true;
                break;
            }
        }

        return result;
    }
}
