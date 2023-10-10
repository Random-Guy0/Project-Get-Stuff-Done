using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class ApplicationListUI : MonoBehaviour
{
    [SerializeField] private Transform applicationsContainer;
    [SerializeField] private ApplicationItem applicationItemPrefab;
    [SerializeField] private TMP_Dropdown dropdown;

    private List<Process> availableProcesses;

    private void Start()
    {
        Process[] allProcesses = Process.GetProcesses();
        availableProcesses = new List<Process>();
        foreach (Process p in allProcesses)
        {
            if (p.MainWindowHandle.ToInt64() != 0)
            {
                dropdown.options.Add(new TMP_Dropdown.OptionData(p.ProcessName));
                availableProcesses.Add(p);
            }
        }

        foreach (Process p in GameManager.Instance.Processes)
        {
            CreateNewApplicationItem(p);
        }
    }

    public void SelectProcess(int index)
    {
        index--;
        
        CreateNewApplicationItem(availableProcesses[index]);
        dropdown.SetValueWithoutNotify(0);
        dropdown.RefreshShownValue();
    }

    private void CreateNewApplicationItem(Process process)
    {
        GameManager.Instance.Processes.Add(process);
        ApplicationItem newApplication = Instantiate(applicationItemPrefab, applicationsContainer);
        newApplication.Process = process;
        newApplication.transform.SetSiblingIndex(applicationsContainer.childCount - 2);
    }
}
