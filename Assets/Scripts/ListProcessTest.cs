using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class ListProcessTest : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;

    private void Start()
    {
        Process[] processes = Process.GetProcesses();
        foreach (Process p in processes)
        {
            if (p.MainWindowHandle.ToInt64() != 0)
            {
                _dropdown.options.Add(new TMP_Dropdown.OptionData(p.ProcessName));
                
            }
        }
    }
}
