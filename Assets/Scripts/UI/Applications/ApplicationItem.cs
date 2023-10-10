using System.Diagnostics;
using TMPro;
using UnityEngine;

public class ApplicationItem : MonoBehaviour
{
    private Process _process;
    public Process Process
    {
        get => _process;
        set
        {
            _process = value;
            applicationNameText.SetText(_process.ProcessName);
        }
    }

    [SerializeField] private TMP_Text applicationNameText;

    public void Delete()
    {
        GameManager.Instance.Processes.Remove(Process);
        Destroy(gameObject);
    }
}